using System.Linq;

namespace _02.VaniPlanning
{
    using System;
    using System.Collections.Generic;

    public class Agency : IAgency
    {
        private Dictionary<string, Invoice> invoices;
        private Dictionary<DateTime, List<Invoice>> dueDate;


        public Agency()
        {
            this.invoices = new Dictionary<string, Invoice>();
            this.dueDate = new Dictionary<DateTime, List<Invoice>>();
        }

        public void Create(Invoice invoice)
        {
            if (this.invoices.ContainsKey(invoice.SerialNumber))
                throw new ArgumentException();

            if (!this.dueDate.ContainsKey(invoice.DueDate))
            {
                this.dueDate.Add(invoice.DueDate, new List<Invoice>());
            }

            this.dueDate[invoice.DueDate].Add(invoice);
            this.invoices.Add(invoice.SerialNumber, invoice);

        }

        public void ThrowInvoice(string number)
        {
            if (!this.invoices.ContainsKey(number))
                throw new ArgumentException();

            this.invoices.Remove(number);

        }

        public void ThrowPayed()
        {
            this.invoices = invoices.Where(i => i.Value.Subtotal != 0).ToDictionary(k => k.Key, v => v.Value);
        }

        public int Count()
        {
            return this.invoices.Count;
        }

        public bool Contains(string number)
        {
            return this.invoices.ContainsKey(number);
        }

        public void PayInvoice(DateTime due)
        {
            if (!this.dueDate.ContainsKey(due))
                throw new ArgumentException();



            foreach (var invoice in invoices.Values)
            {
                if (invoice.DueDate == due)
                {
                    invoice.Subtotal = 0;
                }
            }
        }

        public IEnumerable<Invoice> GetAllInvoiceInPeriod(DateTime start, DateTime end)
        {
            return this.invoices.Values.Where(i => i.IssueDate >= start && i.IssueDate <= end).OrderBy(i => i.IssueDate)
                .ThenBy(i => i.DueDate);
        }

        public IEnumerable<Invoice> SearchBySerialNumber(string serialNumber)
        {
            List<Invoice> toReturn = this.invoices.Values.Where(i => i.SerialNumber.Contains(serialNumber)).OrderByDescending(i => i.SerialNumber).ToList();

            if (toReturn.Count == 0)
                throw new ArgumentException();

            return toReturn;


        }

        public IEnumerable<Invoice> ThrowInvoiceInPeriod(DateTime start, DateTime end)
        {
            List<Invoice> toReturn = this.invoices.Values.Where(i => i.DueDate > start && i.DueDate < end)
                .OrderBy(i => i.SerialNumber).ToList();

            if (toReturn.Count == 0)
                throw new ArgumentException();

            this.invoices = invoices.Values.Where(i => i.DueDate <start || i.DueDate >= end)
                .ToDictionary(k=>k.SerialNumber,v=>v);

            return toReturn;


        }

        public IEnumerable<Invoice> GetAllFromDepartment(Department department)
        {
            return this.invoices.Values.Where(i => i.Department == department).OrderByDescending(i => i.Subtotal)
                .ThenBy(i => i.IssueDate).ToList();
        }

        public IEnumerable<Invoice> GetAllByCompany(string company)
        {
            return this.invoices.Values.Where(i => i.CompanyName == company).OrderByDescending(i => i.SerialNumber);
        }

        public void ExtendDeadline(DateTime dueDate, int days)
        {
            if (!this.dueDate.ContainsKey(dueDate))
                throw new ArgumentException();

            foreach (var invc in invoices.Values)
            {
                if (invc.DueDate.Equals(dueDate))
                {
                    invc.DueDate.AddDays(days);
                }
            }
        }
    }
}
