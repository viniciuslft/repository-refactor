﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace repository1
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void iToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormInserir FInserir = new FormInserir();
            FInserir.Show();
        }

        private void pesquisarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBuscar form = new FormBuscar();
            form.Show();
        }

    }
}
