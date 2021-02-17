using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Bibliotecas específicas para hora e data:
using System.Globalization;
using System.Threading;


namespace Sistema_de_cadastro_Aurineth_Alves
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            //Seta o cursor do teclado no textbox do nome quando a form é chamada pela primeira vez:
            txtboxNome.Select();
            // Define a data atual para o campo especificado (masked text box):
            //mtxtboxDataderegistro.Text = DateTime.Today.ToString("dd/MM/yyyy");
            // Define a hora atual para o campo especificado (masked text box):
            //mtxtboxHoraderegistro.Text = DateTime.Now.ToString("HH:mm:ss");
            //mtxtboxHoraderegistro.Text = DateTime.Now.ToShortDateString();
            //mtxtboxHoraderegistro.Text = DateTime.Now.ToShortTimeString();
        }

        private void editarUsuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime horaEdata = DateTime.Now;
            lbl_data_e_hora.Text = DateTime.Now.ToString("dd/MM/yy " + "HH:mm:ss");
        }

        private void mtxtboxCEP_Enter(object sender, EventArgs e)
        {
            /*
            O código abaixo serve para setar o cursor do teclado
            no início do controle (Masked Text Box) quando ele é
            selecionado.
            O parâmetro TextMaskFormat do controle deve estar
            configurado como: ExcludePromptAndLiterals
            */
            var txtbox = (MaskedTextBox)sender;
            if (string.IsNullOrWhiteSpace(txtbox.Text))
            {
                this.BeginInvoke((MethodInvoker)(() => txtbox.Select(0, 0)));
            }
        }

        private void btnLimparCEP_Click(object sender, EventArgs e)
        {
            mtxtboxCEP.Text = string.Empty;
            txtboxRua.Text = string.Empty;
            txtboxBairro.Text = string.Empty;
            txtboxEstado.Text = string.Empty;
            txtboxCidade.Text = string.Empty;
            txtboxNumero.Text = string.Empty;
            rtxtboxComplemento.Text = string.Empty;
        }

        private void btnPesquisaCorreios_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(mtxtboxCEP.Text))
            {
                using (var ws = new WSCorreios.AtendeClienteClient())
                {
                    try
                    {
                        var endereco = ws.consultaCEP(mtxtboxCEP.Text.Trim());
                        txtboxRua.Text = endereco.end; // Rua.
                        txtboxBairro.Text = endereco.bairro;
                        txtboxCidade.Text = endereco.cidade;
                        txtboxEstado.Text = endereco.uf; // Estado.
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                //MessageBox.Show("Por favor, informe um C.E.P. válido, caso esteja correto, preencha no campo \"Complemento\"!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("Não deixe o campo do C.E.P. vazio!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mtxtboxCPF_Enter(object sender, EventArgs e)
        {
            /*
            O código abaixo serve para setar o cursor do teclado
            no início do controle (Masked Text Box) quando ele é
            selecionado.
            O parâmetro TextMaskFormat do controle deve estar
            configurado como: ExcludePromptAndLiterals
            */
            var txtbox = (MaskedTextBox)sender;
            if (string.IsNullOrWhiteSpace(txtbox.Text))
            {
                this.BeginInvoke((MethodInvoker)(() => txtbox.Select(0, 0)));
            }
        }

        private void mtxtboxRG_Enter(object sender, EventArgs e)
        {
            /*
            O código abaixo serve para setar o cursor do teclado
            no início do controle (Masked Text Box) quando ele é
            selecionado.
            O parâmetro TextMaskFormat do controle deve estar
            configurado como: ExcludePromptAndLiterals
            */
            var txtbox = (MaskedTextBox)sender;
            if (string.IsNullOrWhiteSpace(txtbox.Text))
            {
                this.BeginInvoke((MethodInvoker)(() => txtbox.Select(0, 0)));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            Limpando Combo Box:
            {Nome da combo box}.SelectedIndex = -1;
            Isso será o suficiente para quem habilitou o DropDownList 
            no campo DropDownStyle do componente (a combo box).
            Para quem habilitou somente o DropDown (opção padrão), 
            eu acredito que o parâmetro .SelectedIndex = -1; também 
            possa funcionar, porém, você pode limpar a sua combo box 
            com o seguinte comando:
            {Nome da combo box}.Text = string.Empty; 
            */

            txtboxNome.Text = string.Empty;
            //cbxSexo.Text = string.Empty;
            cbxSexo.SelectedIndex = -1;
            //cbxEstado_Civil.Text = string.Empty;
            cbxEstado_Civil.SelectedIndex = -1;

            mtxtboxCPF.Text = string.Empty;
            mtxtboxRG.Text = string.Empty;
            mtxtboxTitulo_Eleitoral.Text = string.Empty;
            txtboxZona_Eleitoral.Text = string.Empty;
            txtboxSessao_Eleitoral.Text = string.Empty;
            mtxtboxSUS.Text = string.Empty;
            
            //Setando a data do aniversário como a data atual do sistema:
            //Criando variável para lidar com a data atual
            DateTime hoje = DateTime.Today;
            //Calculando a diferença entre hoje e hoje e escrevendo na textBoxExibirIdade:
            CalculoIdade dateDifference = new CalculoIdade(hoje, hoje);
            this.txtBoxExibirIdade.Text = dateDifference.ToString();
            //setando a data do DataTimePicker para o dia de hoje!
            //DateTimePicker dtp_Aniversario = new DateTimePicker; // Não é necessário criar um novo data time picker!
            dtp_Aniversario.Value = DateTime.Now;

            txtboxNomeDaMae.Text = string.Empty;
            mTxtBoxContatoPessoal.Text = string.Empty;

            mtxtboxCEP.Text = string.Empty;
            txtboxRua.Text = string.Empty;
            txtboxBairro.Text = string.Empty;
            txtboxEstado.Text = string.Empty;
            txtboxCidade.Text = string.Empty;
            txtboxNumero.Text = string.Empty;
            rtxtboxComplemento.Text = string.Empty;

            rtxtboxMotivodocadastro.Text = string.Empty;

            //Validando picturebox (vazia ou não):
            if (pBoxImagem.Image == null)
            {
                //Se a picturebox da imagem estiver vazia, não faça nada
            }
            else
            {
                //senão, limpe-a:
                pBoxImagem.Image.Dispose(); //Libera os recursos usados pela picture box.
                pBoxImagem.Image = null; //Seta a imagem da picture box como vazio.
                pBoxImagem.Refresh(); //Atualiza o status da picture box.
            }

            if (checkBox1.Checked || checkBox2.Checked)
            {
                checkBox1.Checked = false; //Mudando o estado da checkbox1:
                checkBox2.Checked = false; //Mudando o estado da checkbox 2:
            }
            else
            {
                //Não faça nada se o checkbox (os dos contatos) estiver desmarcado!
            }


        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            /*
            //Display the Start and End property values of 
            //the SelectionRange object in the text boxes.

            DateTime data = dtp_Aniversario.Value;
            int idade = DateTime.Today.Year - dtp_Aniversario.Value.Year;
            mtxtboxIdade.Text = idade.ToString();
            */

            DateTime hoje = DateTime.Today;

            CalculoIdade dateDifference = new CalculoIdade(this.dtp_Aniversario.Value, hoje);
            this.txtBoxExibirIdade.Text = dateDifference.ToString();

        }

        private void mtxtboxAniversario_Enter(object sender, EventArgs e)
        {
            /*
            O código abaixo serve para setar o cursor do teclado
            no início do controle (Masked Text Box) quando ele é
            selecionado.
            O parâmetro TextMaskFormat do controle deve estar
            configurado como: ExcludePromptAndLiterals
            */
            var txtbox = (MaskedTextBox)sender;
            if (string.IsNullOrWhiteSpace(txtbox.Text))
            {
                this.BeginInvoke((MethodInvoker)(() => txtbox.Select(0, 0)));
            }
        }

        private void mtxtboxSUS_Enter(object sender, EventArgs e)
        {
            /*
            O código abaixo serve para setar o cursor do teclado
            no início do controle (Masked Text Box) quando ele é
            selecionado.
            O parâmetro TextMaskFormat do controle deve estar
            configurado como: ExcludePromptAndLiterals
            */
            var txtbox = (MaskedTextBox)sender;
            if (string.IsNullOrWhiteSpace(txtbox.Text))
            {
                this.BeginInvoke((MethodInvoker)(() => txtbox.Select(0, 0)));
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtBoxNome_Contato.ReadOnly = false;
                mTxtBoxCelular_Contato.ReadOnly = false;
                mTxtBoxTelefone_Contato.ReadOnly = false;
                txtBoxEmail_Contato.ReadOnly = false;
                cbBoxParentesco_Contato.Enabled = true;
            }
            else
            {
                txtBoxNome_Contato.Text = string.Empty;
                mTxtBoxCelular_Contato.Text = string.Empty;
                mTxtBoxTelefone_Contato.Text = string.Empty;
                txtBoxEmail_Contato.Text = string.Empty;
                cbBoxParentesco_Contato.SelectedIndex = -1;

                txtBoxNome_Contato.ReadOnly = true;
                mTxtBoxCelular_Contato.ReadOnly = true;
                mTxtBoxTelefone_Contato.ReadOnly = true;
                txtBoxEmail_Contato.ReadOnly = true;
                cbBoxParentesco_Contato.Enabled = false;
            }

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                txtBoxNome_Contato2.ReadOnly = false;
                mTxtBoxCelular_Contato2.ReadOnly = false;
                mTxtBoxTelefone_Contato2.ReadOnly = false;
                txtBoxEmail_Contato2.ReadOnly = false;
                cbBoxParentesco_Contato2.Enabled = true;
            }
            else
            {
                txtBoxNome_Contato2.Text = string.Empty;
                mTxtBoxCelular_Contato2.Text = string.Empty;
                mTxtBoxTelefone_Contato2.Text = string.Empty;
                txtBoxEmail_Contato2.Text = string.Empty;
                cbBoxParentesco_Contato2.SelectedIndex = -1;

                txtBoxNome_Contato2.ReadOnly = true;
                mTxtBoxCelular_Contato2.ReadOnly = true;
                mTxtBoxTelefone_Contato2.ReadOnly = true;
                txtBoxEmail_Contato2.ReadOnly = true;
                cbBoxParentesco_Contato2.Enabled = false;
            }

        }

        private void mTxtBoxContatoPessoal_Enter(object sender, EventArgs e)
        {
            /*
            O código abaixo serve para setar o cursor do teclado
            no início do controle (Masked Text Box) quando ele é
            selecionado.
            O parâmetro TextMaskFormat do controle deve estar
            configurado como: ExcludePromptAndLiterals
            */
            var txtbox = (MaskedTextBox)sender;
            if (string.IsNullOrWhiteSpace(txtbox.Text))
            {
                this.BeginInvoke((MethodInvoker)(() => txtbox.Select(0, 0)));
            }
        }

        private void mTxtBoxCelular_Contato_Enter(object sender, EventArgs e)
        {
            /*
            O código abaixo serve para setar o cursor do teclado
            no início do controle (Masked Text Box) quando ele é
            selecionado.
            O parâmetro TextMaskFormat do controle deve estar
            configurado como: ExcludePromptAndLiterals
            */
            var txtbox = (MaskedTextBox)sender;
            if (string.IsNullOrWhiteSpace(txtbox.Text))
            {
                this.BeginInvoke((MethodInvoker)(() => txtbox.Select(0, 0)));
            }
        }

        private void mTxtBoxTelefone_Contato_Enter(object sender, EventArgs e)
        {
            /*
            O código abaixo serve para setar o cursor do teclado
            no início do controle (Masked Text Box) quando ele é
            selecionado.
            O parâmetro TextMaskFormat do controle deve estar
            configurado como: ExcludePromptAndLiterals
            */
            var txtbox = (MaskedTextBox)sender;
            if (string.IsNullOrWhiteSpace(txtbox.Text))
            {
                this.BeginInvoke((MethodInvoker)(() => txtbox.Select(0, 0)));
            }
        }

        private void mTxtBoxCelular_Contato2_Enter(object sender, EventArgs e)
        {
            /*
            O código abaixo serve para setar o cursor do teclado
            no início do controle (Masked Text Box) quando ele é
            selecionado.
            O parâmetro TextMaskFormat do controle deve estar
            configurado como: ExcludePromptAndLiterals
            */
            var txtbox = (MaskedTextBox)sender;
            if (string.IsNullOrWhiteSpace(txtbox.Text))
            {
                this.BeginInvoke((MethodInvoker)(() => txtbox.Select(0, 0)));
            }
        }

        private void mTxtBoxTelefone_Contato2_Enter(object sender, EventArgs e)
        {
            /*
            O código abaixo serve para setar o cursor do teclado
            no início do controle (Masked Text Box) quando ele é
            selecionado.
            O parâmetro TextMaskFormat do controle deve estar
            configurado como: ExcludePromptAndLiterals
            */
            var txtbox = (MaskedTextBox)sender;
            if (string.IsNullOrWhiteSpace(txtbox.Text))
            {
                this.BeginInvoke((MethodInvoker)(() => txtbox.Select(0, 0)));
            }
        }

        private void btnSelecionarImagem_Click(object sender, EventArgs e)
        {
            //Iniciando OPEN FILE DIALOG para selecionar imagem:
            ofdpBoxImagem.FileName = ""; //Sem imagem préselecionada!//Título da caixa de diálogo.
            ofdpBoxImagem.Title = "Selecionar foto"; //Título da caixa de diálogo.
            ofdpBoxImagem.Filter = "JPEG|*.JPG|PNG|*.png"; //Tipos de arquivos que serão permitidos, o símbolo "|" separa os parâmetros!
            ofdpBoxImagem.ShowDialog(); //Chama a caixa de diálogo.
        }

        private void ofdpBoxImagem_FileOk(object sender, CancelEventArgs e)
        {
            pBoxImagem.Image = Image.FromFile(ofdpBoxImagem.FileName);
        }

        private void btnLimparFoto_Click(object sender, EventArgs e)
        {
            if (pBoxImagem.Image == null)
            {
                //Nada faça!
            }
            else
            {
                pBoxImagem.Image.Dispose(); //Libera os recursos usados pela picture box.
                pBoxImagem.Image = null; //Seta a imagem da picture box como vazio.
                pBoxImagem.Refresh(); //Atualiza o status da picture box.
            }
        }

        private void lbl_data_e_hora_TextChanged(object sender, EventArgs e)
        {
            /*Esse evento altera a data e a hora de uma textbox toda vez que o texto é modificado,
            então, a cada alteração de texto na label desse controle, o valor das textboxes serão
            modificados.
             */
            // Define a data atual para o campo especificado (masked text box):
            mtxtboxDataderegistro.Text = DateTime.Today.ToString("dd/MM/yyyy");
            // Define a hora atual para o campo especificado (masked text box):
            mtxtboxHoraderegistro.Text = DateTime.Now.ToString("HH:mm:ss");
            //mtxtboxHoraderegistro.Text = DateTime.Now.ToShortDateString();
            //mtxtboxHoraderegistro.Text = DateTime.Now.ToShortTimeString();
        }

        private void rtxtboxComplemento_TextChanged(object sender, EventArgs e)
        {
            int totalCaracteres = 500; //Quantidade máxima de caracteres do meu controle.
            //Essa quantidade deve ser igual a propriedade MaxLength do controle que você precisa!
            foreach (char item in rtxtboxComplemento.Text)
            {
                totalCaracteres = totalCaracteres - 1;
            }
            lblCaracteresComplemento.Text = "Restam " + totalCaracteres + " caracteres.";
            
            if(totalCaracteres == 0)
            {
                //Defina a propriedade MaxLength = 500 para o RicthTextBox, porque o total de caracteres é 500!
                lblCaracteresComplemento.Text = "Você não pode mais digitar!";
            }
            else
            {
                //Não preciso fazer nada se o contador de caracteres for diferente de zero
            }
        }

        private void rtxtboxMotivodocadastro_TextChanged(object sender, EventArgs e)
        {
            int totalCaracteres = 500; //Quantidade máxima de caracteres do meu controle.
            //Essa quantidade deve ser igual a propriedade MaxLength do controle que você precisa!
            foreach (char item in rtxtboxMotivodocadastro.Text)
            {
                totalCaracteres = totalCaracteres - 1;
            }
            lblCaracteresComplemento2.Text = "Restam " + totalCaracteres + " caracteres.";

            if (totalCaracteres == 0)
            {
                //Defina a propriedade MaxLength = 500 para o RicthTextBox, porque o total de caracteres é 500!
                lblCaracteresComplemento2.Text = "Você não pode mais digitar!";
            }
            else
            {
                //Não preciso fazer nada se o contador de caracteres for diferente de zero
            }
        }
    }
}
