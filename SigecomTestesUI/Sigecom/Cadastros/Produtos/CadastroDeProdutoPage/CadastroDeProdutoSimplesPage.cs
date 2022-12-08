﻿using NUnit.Framework;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.CadastroDeProdutoPage.Interfaces;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.EditarProduto.Model;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.Model;
using SigecomTestesUI.Sigecom.Cadastros.Produtos.PesquisaProduto;
using System;
using System.Threading;
using OpenQA.Selenium;
using DriverService = SigecomTestesUI.Services.DriverService;

namespace SigecomTestesUI.Sigecom.Cadastros.Produtos.CadastroDeProdutoPage
{
    public class CadastroDeProdutoSimplesPage : ICadastroDeProdutoPage
    {
        private readonly DriverService _driverService;

        public CadastroDeProdutoSimplesPage(DriverService driver) => 
            _driverService = driver;

        public bool PreencherCamposDoProduto()
        {
            try
            {
                _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoNomeProduto, CadastroDeProdutoSimplesModel.NomeDoProduto);
                _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoUnidade, CadastroDeProdutoBaseModel.UnidadeDoProduto);
                _driverService.DigitarNoCampoComTeclaDeAtalhoId(CadastroDeProdutoModel.ElementoCategoria, CadastroDeProdutoSimplesModel.CategoriaDoProduto, Keys.Enter);
                Thread.Sleep(TimeSpan.FromSeconds(2));
                _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoCusto, CadastroDeProdutoBaseModel.CustoDoProduto);
                _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoMarkup, CadastroDeProdutoBaseModel.MarkupDoProduto);
                _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoReferencia, CadastroDeProdutoBaseModel.ReferenciaDoProduto);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool PreencherCamposDoProdutoAoEditar()
        {
            try
            {
                _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoNomeProduto, EditarProdutoNovoSimplesModel.NomeDoProduto);
                _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoUnidade, EditarProdutoNovoSimplesModel.UnidadeDoProduto);
                _driverService.DigitarNoCampoComTeclaDeAtalhoId(CadastroDeProdutoModel.ElementoCategoria, EditarProdutoNovoSimplesModel.CategoriaDoProduto, Keys.Enter);
                Thread.Sleep(TimeSpan.FromSeconds(2));
                _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoCusto, EditarProdutoNovoSimplesModel.CustoDoProduto);
                _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoMarkup, EditarProdutoNovoSimplesModel.MarkupDoProduto);
                _driverService.DigitarNoCampoId(CadastroDeProdutoModel.ElementoReferencia, EditarProdutoNovoSimplesModel.ReferenciaDoProduto);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool PreencherCamposDaAba()
        {
            return false;
            //Não utilizado;
        }

        public void PreencherCamposDaAbaAoEditar()
        {
            throw new NotImplementedException();
        }

        public void VerificarCamposDoProduto()
        {
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoNomeProduto), CadastroDeProdutoSimplesModel.NomeDoProduto);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoUnidade), CadastroDeProdutoBaseModel.UnidadeDoProduto);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoCategoria), CadastroDeProdutoSimplesModel.CategoriaDoProduto);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoCusto), CadastroDeProdutoBaseModel.CustoDoProduto);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoMarkup), CadastroDeProdutoBaseModel.MarkupDoProduto);
            Assert.AreEqual(_driverService.ObterValorElementoId(CadastroDeProdutoModel.ElementoReferencia), CadastroDeProdutoBaseModel.ReferenciaDoProduto);
        }

        private static void FluxoDePesquisaDoProduto(CadastroDeProdutoBasePage cadastroDeProdutoBasePage, PesquisaDeProdutoPage pesquisaDeProdutoPage, string nomeDoProduto)
        {
            cadastroDeProdutoBasePage.FecharJanelaCadastroDeProdutoComEsc();
            cadastroDeProdutoBasePage.ClicarNoAtalhoDePesquisarNaTelaPrincipal();
            pesquisaDeProdutoPage.PesquisarProdutoComEnter(nomeDoProduto);
            var possuiProduto = pesquisaDeProdutoPage.VerificarSeExisteProdutoNaGrid(nomeDoProduto);
            Assert.True(possuiProduto);
            pesquisaDeProdutoPage.FecharJanelaComEsc();
        }

        public void FluxoDePesquisaDoProduto(CadastroDeProdutoBasePage cadastroDeProdutoBasePage, PesquisaDeProdutoPage pesquisaDeProdutoPage) => 
            FluxoDePesquisaDoProduto(cadastroDeProdutoBasePage, pesquisaDeProdutoPage, CadastroDeProdutoSimplesModel.NomeFinalDoProduto);

        public void FluxoDePesquisaDoProdutoEditado(CadastroDeProdutoBasePage cadastroDeProdutoBasePage, PesquisaDeProdutoPage pesquisaDeProdutoPage) => 
            FluxoDePesquisaDoProduto(cadastroDeProdutoBasePage, pesquisaDeProdutoPage, EditarProdutoNovoSimplesModel.NomeFinalDoProduto);
    }
}
