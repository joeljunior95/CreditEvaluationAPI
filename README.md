# CreditEvaluationAPI
API simples feita em .NET Core que avalia um pedido de empréstimo conforme regras específicas.

## Regras de Negócio
 Esta aplicação considera os seguintes tipos de créditos e atribui determinadas taxa fixas a eles:
• Crédito Direto - Taxa de 2%;
• Crédito Consignado - Taxa de 1%;
• Crédito Pessoa Jurídica - Taxa de 5%;
• Crédito Pessoa Física - Taxa de 3%;
• Crédito Imobiliário - Taxa de 9%.

As validações feitas são as seguintes:
• O valor máximo a ser liberado para qualquer tipo de empréstimo é de R$ 1.000.000,00;
• A quantidade mínima de parcelas é de 5x e a máxima é de 72x;
• Para o crédito de pessoa jurídica, o valor mínimo a ser liberado é de R$ 15.000,00;
• A data do primeiro vencimento sempre será no mínimo 15 dias e no máximo 40 dias a
partir da data atual.

A aplicação retorna o seguinte
• Status do crédito (Aprovado ou recusado, de acordo com as premissas acima);
• Valor total com juros (O valor total é calculado baseando-se no principal aplicado à taxa de juros específica pelo tempo determinado);
• Valor dos juros.
 
## Utilização
 Para utilizar a aplicação faça uma requisição POST para o endpoint https://<servidor>:<porta>/CreditEvaluation
 Exemplo de requisição:
{
  "vlLoan": 15000,
  "type": 2,
  "qtyInstalment": 70,
  "stInstalmentDate": "2022-12-03"
}


Exemplo de retorno:
{
  "status": "Aprovado",
  "vlFinal": 19938.63869395439,
  "vlInterest": 4938.638693954392
}
