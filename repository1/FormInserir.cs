using System;
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
    public partial class FormInserir: Form
    {
        //private readonly ClienteRepository _clienteRepository;
        ClienteRepository _clienteRepository = new ClienteRepository();
        public FormInserir()
        {
            InitializeComponent();
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var cliente = new Cliente
                {
                    IdClientes = int.Parse(textID.Text.Trim()),
                    Nome = textNome.Text.Trim(),
                    Endereco = textEndereco.Text.Trim(),
                    Telefone = textFone.Text.Trim()
                };

                bool sucesso = _clienteRepository.Inserir(cliente);

                if (sucesso is false)
                    MessageBox.Show("Erro ao inserir");
                else
                    MessageBox.Show("Inserido com sucesso");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Erro");
            }
        }
    }
}
