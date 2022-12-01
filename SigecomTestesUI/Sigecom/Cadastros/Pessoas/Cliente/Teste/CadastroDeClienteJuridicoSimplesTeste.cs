﻿using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.PesquisaPessoa;
using System;
using System.Collections.Generic;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.Teste
{
    public class CadastroDeClienteJuridicoSimplesTeste : BaseTestes
    {
        private readonly Dictionary<string, string> _dadosDoCliente = new Dictionary<string, string>
        {
            {"Nome","EMPRESA TESTE SIMPLES"},
            {"Cnpf","21010848000171"},
            {"Cep","15700082"},
            {"Numero","623"}
        };

        [Test(Description = "Cadastro de cliente jurídico somente campos obrigatórios com endereço")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Cadastros")]
        [AllureSubSuite("Cliente")]
        public void CadastrarClienteJuridicoSomenteCamposObrigatorios()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var resolveCadastroDeProdutoJuridicoPage = beginLifetimeScope.Resolve<Func<DriverService, Dictionary<string, string>, CadastroDeClienteJuridicoPage>>();
            var cadastroDeProdutoJuridicoPage = resolveCadastroDeProdutoJuridicoPage(DriverService, _dadosDoCliente);
            // Arange
            cadastroDeProdutoJuridicoPage.ClicarNaOpcaoDoMenu();
            cadastroDeProdutoJuridicoPage.ClicarNaOpcaoDoSubMenu();
            cadastroDeProdutoJuridicoPage.ClicarBotaoNovo();
            cadastroDeProdutoJuridicoPage.VerificarTipoPessoa();

            // Act
            cadastroDeProdutoJuridicoPage.PreencherCamposSimples();
            cadastroDeProdutoJuridicoPage.GravarCadastro();

            // Assert
            cadastroDeProdutoJuridicoPage.ClicarBotaoPesquisar();
            var resolvePesquisaDePessoaPage = beginLifetimeScope.Resolve<Func<DriverService, PesquisaDePessoaPage>>();
            var pesquisaDePessoaPage = resolvePesquisaDePessoaPage(DriverService);
            pesquisaDePessoaPage.PesquisarPessoa("cliente", _dadosDoCliente["Nome"]);
            var existeClienteNaPesquisa = pesquisaDePessoaPage.VerificarSeExistePessoaNaGrid(_dadosDoCliente["Nome"]);
            Assert.True(existeClienteNaPesquisa);
            pesquisaDePessoaPage.FecharJanelaComEsc("cliente");
            cadastroDeProdutoJuridicoPage.FecharJanelaComEsc();
        }
    }
}
