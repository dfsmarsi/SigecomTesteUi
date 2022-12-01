﻿using System;
using System.Collections.Generic;
using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.PesquisaPessoa;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente.Teste
{
    public class CadastroDeClienteFisicoSimplesTeste : BaseTestes
    {
        private readonly Dictionary<string, string> _dadosDoCliente = new Dictionary<string, string>
        {
            {"Nome","JOAO PENCA SIMPLES"},
            {"Cpf","25535468070"},
            {"Cep","15700082"},
            {"Numero","123"}
        };

        [Test(Description = "Cadastro de cliente físico somente campos obrigatórios com endereço")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Douglas")]
        [AllureSuite("Cadastros")]
        [AllureSubSuite("Cliente")]
        public void CadastrarClienteFisicoSomenteCamposObrigatorios()
        {
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var resolveCadastroDeProdutoPage = beginLifetimeScope.Resolve<Func<DriverService, Dictionary<string, string>, CadastroDeClienteFisicoPage>>();
            var cadastroDeClientePage = resolveCadastroDeProdutoPage(DriverService, _dadosDoCliente);
            // Arange
            cadastroDeClientePage.ClicarNaOpcaoDoMenu();
            cadastroDeClientePage.ClicarNaOpcaoDoSubMenu();
            cadastroDeClientePage.ClicarBotaoNovo();
            cadastroDeClientePage.VerificarTipoPessoa();

            // Act
            cadastroDeClientePage.PreencherCamposSimples();
            cadastroDeClientePage.GravarCadastro();

            // Assert
            cadastroDeClientePage.ClicarBotaoPesquisar(); 
            var resolvePesquisaDePessoaPage = beginLifetimeScope.Resolve<Func<DriverService, PesquisaDePessoaPage>>();
            var pesquisaDePessoaPage = resolvePesquisaDePessoaPage(DriverService);
            pesquisaDePessoaPage.PesquisarPessoa("cliente", _dadosDoCliente["Nome"]);
            var existeClienteNaPesquisa = pesquisaDePessoaPage.VerificarSeExistePessoaNaGrid(_dadosDoCliente["Nome"]);
            Assert.True(existeClienteNaPesquisa);
            pesquisaDePessoaPage.FecharJanelaComEsc("cliente");
            cadastroDeClientePage.FecharJanelaComEsc();
        }
    }
}
