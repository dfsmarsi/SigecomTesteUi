﻿using System;
using System.Linq;
using SigecomTestesUI.Config;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.PesquisaProduto.Model;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.PesquisaProduto
{
    public class PesquisaDeProdutoPage : PageObjectModel
    {
        public PesquisaDeProdutoPage(DriverService driver) : base(driver) { }

        public void PesquisarProduto(string nomeDoProduto)
        {
            DriverService.ValidarElementoExistentePorNome(PesquisaDeProdutoModel.TelaPesquisaDeProdutoPrefixo);
            DriverService.DigitarNoCampoEnterId(PesquisaDeProdutoModel.ElementoParametroDePesquisa, nomeDoProduto);
        }

        public void PesquisarProdutoComConfirmar(string nomeDoProduto)
        {
            DriverService.ValidarElementoExistentePorNome(PesquisaDeProdutoModel.TelaPesquisaDeProdutoPrefixo);
            DriverService.DigitarNoCampoIdEnterComF5(PesquisaDeProdutoModel.ElementoParametroDePesquisa, nomeDoProduto);
        }


        public bool VerificarSeExisteProdutoNaGrid(string nomeDoProduto)
        {
            var nomeDoProdutoNaGrid = DriverService.PegarValorDaColunaDaGrid("Nome");
            return nomeDoProduto == nomeDoProdutoNaGrid;
        }

        public bool VerificarSeExisteProdutoNaGrid()
        {
            var nomeDoProdutoNaGrid = DriverService.PegarValorDaColunaDaGrid("Nome");
            return nomeDoProdutoNaGrid.Any();
        }

        public bool FecharJanelaComEsc()
        {
            try
            {
                DriverService.FecharJanelaComEsc(PesquisaDeProdutoModel.TelaPesquisaDeProdutoPrefixo);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}