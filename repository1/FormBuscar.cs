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
    public partial class FormBuscar : Form
    {
        private readonly ClienteRepository _clienteRepository;

        public FormBuscar()
        {
            InitializeComponent();
            _clienteRepository = new ClienteRepository();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textID.Text.Trim(), out int id))
            {
                var cliente = _clienteRepository.BuscarPorId(id);

                if (cliente != null)
                {
                    textNome.Text = cliente.Nome;
                    textEndereco.Text = cliente.Endereco;
                    textFone.Text = cliente.Telefone;

                    textNome.Enabled = true;
                    textEndereco.Enabled = true;
                    textFone.Enabled = true;
                    btnSalvar.Enabled = true;
                    btnExcluir.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Cliente não encontrado.");
                }
            }
            else
            {
                MessageBox.Show("ID inválido.");
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            var cliente = new Cliente
            {
                IdClientes = int.Parse(textID.Text.Trim()),
                Nome = textNome.Text.Trim(),
                Endereco = textEndereco.Text.Trim(),
                Telefone = textFone.Text.Trim()
            };

            bool sucesso = _clienteRepository.Atualizar(cliente);

            if (sucesso)
                MessageBox.Show("Cliente atualizado com sucesso.");
            else
                MessageBox.Show("Erro ao atualizar.");
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja excluir?", "Confirmação", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int id = int.Parse(textID.Text.Trim());
                bool sucesso = _clienteRepository.Excluir(id);

                if (sucesso)
                {
                    MessageBox.Show("Cliente excluído.");
                    textNome.Text = textEndereco.Text = textFone.Text = "";
                }
                else
                {
                    MessageBox.Show("Erro ao excluir.");
                }
            }
        }
    }
}