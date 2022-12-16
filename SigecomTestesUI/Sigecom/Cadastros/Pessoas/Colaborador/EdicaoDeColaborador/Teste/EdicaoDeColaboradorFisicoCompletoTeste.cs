﻿using Autofac;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.ControleDeInjecao;
using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Cliente;
using SigecomTestesUI.Sigecom.Cadastros.Pessoas.Colaborador.EdicaoDeColaborador.Page;
using System;

namespace SigecomTestesUI.Sigecom.Cadastros.Pessoas.Colaborador.EdicaoDeColaborador.Teste
{
    public class EdicaoDeColaboradorFisicoCompletoTeste : BaseTestes
    {
        [Test(Description = "Edição de colaborador completo")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Editar")]
        [AllureSubSuite("Colaborador")]
        public void CadastrarColaboradorCompleto()
        {
            // Arange
            using var beginLifetimeScope = ControleDeInjecaoAutofac.Container.BeginLifetimeScope();
            var resolveEdicaoDeColaboradorBasePage = beginLifetimeScope.Resolve<Func<DriverService, EdicaoDeColaboradorBasePage>>();
            var edicaoDeColaboradorBasePage = resolveEdicaoDeColaboradorBasePage(DriverService);
            const ClassificacaoDePessoa classificacaoDePessoa = ClassificacaoDePessoa.FisicaCompleta;
            edicaoDeColaboradorBasePage.PesquisarColaboradorQueSeraEditado(classificacaoDePessoa);

            // Act
            edicaoDeColaboradorBasePage.VerificarInformacoesDoColaborador(classificacaoDePessoa);
            edicaoDeColaboradorBasePage.PreencherAsInformacoesDaPessoasNaEdicao(classificacaoDePessoa);
            edicaoDeColaboradorBasePage.Gravar();

            // Assert
            edicaoDeColaboradorBasePage.FluxoDePesquisaDaPessoaEditado(classificacaoDePessoa);
            edicaoDeColaboradorBasePage.VerificarDadosDaPessoaEditados(classificacaoDePessoa);
            edicaoDeColaboradorBasePage.FecharJanelaCadastroDeColaboradorComEsc();
        }
    }
}
