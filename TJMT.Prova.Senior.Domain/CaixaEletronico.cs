using System;
using System.Collections.Generic;
using System.Linq;
using TJMT.Prova.Senior.Domain.ValueObjects;

namespace TJMT.Prova.Senior.Domain
{
	public class CaixaEletronico
	{
		private IReadOnlyList<Cedula> _cedulasDisponiveis = new List<Cedula>() { CedulaStub.Dez, CedulaStub.Vinte, CedulaStub.Cinquenta, CedulaStub.Cem };

		public List<Cedula> Sacar(decimal valor)
		{
			if (valor <= 0M) throw new InvalidOperationException("Não é possível sacar um valor negativo.");

			var existeCedulaDisponivelParaOValor = _cedulasDisponiveis.Any(x => valor % x.Valor == 0);
			if (!existeCedulaDisponivelParaOValor) throw new InvalidOperationException("Não existem cédulas disponíveis para esse valor. Tente outro valor para saque.");

			var cedulas = new List<Cedula>();

			var auxValor = valor;

			while(auxValor > 0)
			{
				var cedulasOrdenadasPorValorDesc = _cedulasDisponiveis.OrderByDescending(x => x.Valor);

				foreach (var item in cedulasOrdenadasPorValorDesc)
				{
					if(auxValor - item.Valor >= 0)
					{
						cedulas.Add(item);
						auxValor -= item.Valor;
						break;
					}
				}
			}

			return cedulas;

		}
	}
}
