using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsPayment
    {
        enum enMode { Add, Update }
        enMode _Mode = enMode.Add;

        public int PaymentID { get; set; }
        public int Amount { get; set; }
        public int PaidAmount { get; set; }
        public int Balance { get {  return Amount - PaidAmount; } }
        public int StudentID { get; set; }
        clsStudent _Student;
        public clsStudent StudentInfo { get { return _Student; } }

        public DateTime DueDate { get; set; }

        public clsPayment()
        {
            PaymentID = 0;
            Amount = 0;
            PaidAmount = 0;
            DueDate = DateTime.MinValue;

            _Mode = enMode.Add;
        }

        public clsPayment(int paymentID, int amount, int paidAmount, DateTime dueDate, int studentID)
        {
            PaymentID = paymentID;
            Amount = amount;
            PaidAmount = paidAmount;
            DueDate = dueDate;
            StudentID = studentID;

            _Mode = enMode.Update;
        }

        static public clsPayment Find(int paymentID)
        {
            int amount = 0;
            int paidAmount = 0;
            int studentID = 0;
            DateTime dueDate = DateTime.MinValue;

            if (clsPaymentData.GetPaymentByPaymentID(paymentID, ref amount, ref paidAmount, ref dueDate, ref studentID))
            {
                return new clsPayment(paymentID, amount, paidAmount, dueDate, studentID);
            }

            return null;
        }

        static public clsPayment FindByStudentID(int studentID)
        {
            int amount = 0;
            int paidAmount = 0;
            int paymentID = 0;
            DateTime dueDate = DateTime.MinValue;

            if (clsPaymentData.GetPaymentByStudentID(studentID, ref amount, ref paidAmount, ref dueDate, ref paymentID))
            {
                return new clsPayment(paymentID, amount, paidAmount, dueDate, studentID);
            }

            return null;
        }

        static public bool IsExistByPaymentID(int paymentID)
        {
            return clsPaymentData.IsExistByPaymentID(paymentID);
        }

        static public bool IsExistByStudentID(int StudentID)
        {
            return clsPaymentData.IsExistByStudentID(StudentID);
        }

        static public bool Delete(int paymentID)
        {
            return clsPaymentData.DeletePayment(paymentID);
        }

        static public DataTable GetPayments()
        {
            return clsPaymentData.GetPayments();
        }

        // Add New Payment Info
        private bool _Add()
        {
            int resultPaymentID = clsPaymentData.AddNewPayment(Amount, PaidAmount, DueDate, StudentID);

            if (resultPaymentID > 0)
            {
                this.PaymentID = resultPaymentID;
                _Student = clsStudent.FindByStudentID(this.StudentID);
                return true;
            }

            return false;
        }

        // Update Payment Info
        private bool _Update()
        {
            if(clsPaymentData.UpdatePaymentInfo(PaymentID, Amount, PaidAmount, DueDate, StudentID))
            {
                _Student = clsStudent.FindByStudentID(StudentID);
                return true;
            }

            return false;
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.Add:
                    if (_Add())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _Update();
            }

            return false;
        }
    }

}
