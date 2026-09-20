using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel.Invoices
{
    public partial class frmShowInvoiceInfo : Form
    {
        private int _InvoiceID = -1;

        public frmShowInvoiceInfo(int InvoiceID)
        {
            InitializeComponent();
            _InvoiceID = InvoiceID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowInvoiceInfo_Load(object sender, EventArgs e)
        {
            ctrlInvoiceCard1.LoadInvoiceInfo(_InvoiceID);
        }
    }
}
