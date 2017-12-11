using System;
using System.Collections.Generic;
using TJMT.Prova.Senior.Domain;
using TJMT.Prova.Senior.Domain.ValueObjects;

namespace TJMT.Prova.Senior
{
	class Program
	{
		static void Main(string[] args)
		{
			var caixaEletronico = new CaixaEletronico();

			while (true)
			{
				Console.Clear();
				Console.Write("/***************** Bem vindo ao Banco do TJMT *****************/");
				Console.Write("\n\n");
				Console.Write("Informe um valor para saque: ");

				decimal valorSaque = 0;

				if (!decimal.TryParse(Console.ReadLine(), out valorSaque))
				{
					Console.Write("Valor Inválido");
				}
				else
				{
					try
					{
						var cedulas = caixaEletronico.Sacar(valorSaque);
						ImprimirCedulas(cedulas);
					}
					catch (Exception e)
					{
						Console.Write("Erro: " + e.Message);
					}

				}

				Console.ReadKey();

			}

		}


		static void ImprimirCedulas(List<Cedula> cedulas)
		{
			Console.Clear();
			Console.WriteLine("Saque realizado com sucesso!");

			foreach (var cedula in cedulas)
			{
				Console.WriteLine("=> " + cedula.Valor);
			}
		}
	}
}
