﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Login_teste.Modelo;
using MySql.Data.MySqlClient;
using System.Threading;

namespace Login_teste.View
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedDialog;
        }
        Thread th;

        private void button1_Click(object sender, EventArgs e)
        {
            ProjetoEntrar controle = new ProjetoEntrar();
            controle.acessar(txtLogin.Text, txtSenha.Text);
            if (controle.mensagem.Equals(""))
            {

                if (controle.existe)
                {
                    MessageBox.Show("Login efetuado com Sucesso!!", "Entrando", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    th = new Thread(AbrirHome);
                    th.SetApartmentState(ApartmentState.STA);
                    th.Start();
                }
                else
                {
                    MessageBox.Show("Login ou Senha não encontrados!!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(controle.mensagem);
            }
        }

        private void AbrirHome()
        {
            Application.Run(new Home());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(AbrirCriar);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void AbrirCriar()
        {
            Application.Run(new NewLogin());
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtLogin_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSenha_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
