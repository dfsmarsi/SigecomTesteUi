﻿using NUnit.Allure.Attributes;
using NUnit.Framework;
using SigecomTestesUI.Sigecom.Cadastros.Categoria.Model;
using System.Collections.Generic;

namespace SigecomTestesUI.Sigecom.Cadastros.Categoria.Teste
{
    public class CadastroDeCategoriaMedicamentoTeste : CadastroDeCategoriaBaseTeste
    {
        [Test(Description = "Cadastro de Categoria de Medicamento Somente Campos Obrigatorios")]
        [AllureTag("CI")]
        [AllureSeverity(Allure.Commons.SeverityLevel.trivial)]
        [AllureIssue("1")]
        [AllureTms("1")]
        [AllureOwner("Takaki")]
        [AllureSuite("Cadastros")]
        [AllureSubSuite("Categoria")]
        public void CadastrarCategoriaMedicamentoSomenteCamposObrigatorios()
        {
            var dadosDeCategoriaMedicamento = new Dictionary<string, string>
            {
                {"Grupo", "GRUPO MEDICAMENTO"},
                {"Markup", "0"}
            };

            // Arange
            RetornarCadastroDeCategoria(dadosDeCategoriaMedicamento, out var cadastroDeCategoriaPage);
            AbrirTelaDeCategoriaParaTeste(cadastroDeCategoriaPage);

            // Act
            cadastroDeCategoriaPage.PreencherCamposDaCategoria(CadastroDeCategoriaModel.ElementoToggleMedicamento);
            cadastroDeCategoriaPage.Gravar();

            // Assert
            PesquisarCategoriaGravada(cadastroDeCategoriaPage, dadosDeCategoriaMedicamento);
        }
    }
}
