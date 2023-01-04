﻿using SigecomTestesUI.Services;
using SigecomTestesUI.Sigecom.Vendas.PDV.Enum;
using SigecomTestesUI.Sigecom.Vendas.PDV.Model;
using SigecomTestesUI.Sigecom.Vendas.PDV.Page.Interfaces;

namespace SigecomTestesUI.Sigecom.Vendas.PDV.Page
{
    public class LancarVendaNoBancoPage:ILancarFormaDePagamentoPage
    {
        private readonly DriverService _driverService;

        public LancarVendaNoBancoPage(DriverService driverService) => _driverService = driverService;

        public void RealizarFluxoDeLancarVendaNoPdv(LancarVendaNaFormaDePagamentoPage lancarVendaNaFormaDePagamentoPage, FormaDePagamento formaDePagamento)
        {
            lancarVendaNaFormaDePagamentoPage.ClicarNaOpcaoDoMenu();
            lancarVendaNaFormaDePagamentoPage.ClicarNaOpcaoDoSubMenu();
            lancarVendaNaFormaDePagamentoPage.LancarItemNoPedido();
            lancarVendaNaFormaDePagamentoPage.PagarPedido();
            SelecionarFormaDePagamento();
            _driverService.ClicarBotaoName(", Confirmar (ENTER)");
            lancarVendaNaFormaDePagamentoPage.ConcluirPedido();
            lancarVendaNaFormaDePagamentoPage.FecharTelaDeVendaComEsc();
        }

        private void SelecionarFormaDePagamento() => 
            _driverService.RealizarSelecaoDaFormaDePagamento(PdvModel.GridDeFormaDePagamento, 5);
    }
}
