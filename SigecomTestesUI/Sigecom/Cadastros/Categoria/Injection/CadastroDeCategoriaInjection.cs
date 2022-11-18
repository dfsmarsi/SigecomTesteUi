﻿using Autofac;
using SigecomTestesUI.ControleDeInjecao;
using System;
using SigecomTestesUI.Sigecom.Pesquisa.PesquisaDeCategoria;

namespace SigecomTestesUI.Sigecom.Cadastros.Categoria.Injection
{
    public class CadastroDeCategoriaInjection : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            try
            {
                containerBuilder.RegisterType<CadastroDeCategoriaPage>();
                containerBuilder.RegisterType<CadastroDeCategoriaTeste>();
                containerBuilder.RegisterType<PesquisaDeCategoriaPage>();
            }
            catch (Exception exception)
            {
                throw new RegistrarDependenciaException(typeof(CadastroDeCategoriaInjection).Namespace, exception);
            }
        }
    }
}
