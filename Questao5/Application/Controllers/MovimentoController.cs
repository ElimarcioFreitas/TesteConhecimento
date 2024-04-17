using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Questao5.Application.Controllers;

namespace Questao5.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovimentoController : ControllerBase
    {
        public List<Movimento> mov = new List<Movimento>();
        public List<ContaCorrente> cc = new List<ContaCorrente>();
        public List<IdEmpotencia> emptc = new List<IdEmpotencia>();
        
        [HttpGet("Movimento/{idReq}/{idCC}/{tpMov}/{valor}")]
        public ActiontResult<mov> Movimento(string idReq, string idCC, string tpMov, double valor){

            var indexCC = cc.IndexOf(idcc);
            var cCorrente = cc[indexCC];
  
            if (idReq == null || idReq = ""){
                return BadRequestResult("[INVALID_REQUISITION] - Não foi possível identificar a requisição.[OPERAÇÃO NÃO CONCLUÍDA]");           
            } else if(indCC == -1){
                return BadRequestResult("[INVALID_ACCOUNT] - Conta não identificada. Confirme o número da conta e tente novamente.[OPERAÇÃO NÃO CONCLUÍDA]");
            } else if(cCorrente.ativo == 0){
                return BadRequestResult("[INACTIVE_ACCOUNT] - A conta indicada está inativa.[OPERAÇÃO NÃO CONCLUÍDA]");
            } else if (tpMov.toUpper != "C" && tpMov.toUpper != "D"){
                return BadRequestResult("[INVALID_TYPE] - Tipo de movimento invalido. Indique C para CREDITO ou D para DÉBITO e tente novamente.[OPERAÇÃO NÃO CONCLUÍDA]");
            } else if (valor < 0 ){
                return BadRequestResult("[INVALID_VALUE] - Operação não suporta valor negativo. Corrija o valor e tente novamente.[OPERAÇÃO NÃO CONCLUÍDA]");                
            } else {
                DateTime dataMov = DateTime.Today;

                mov.add(idCC, dataMov.toString(), tpMov, valor);

                var movGerado = mov.last();

                emptc.add(idReq, Movimento.GetRequestStream(),movGerado.idmovimento);

                return OK("Movimento gerado com sucesso! ID do Movimento: " + movGerado.idmovimento);
            }
        }

        [HttpGet("Saldo/{idCC}")]
        public ActiontResult<mov> Saldo(string idCC){

            var indexCC = cc.IndexOf(idcc);
            var cCorrente = cc[indexCC];
            DateTime dataRet = DateTime.Today;

            double valorC = 0;
            double valorD = 0;
            double valorS = 0;

            if(indCC == -1){
                return BadRequestResult("[INVALID_ACCOUNT] - Conta não identificada. Confirme o número da conta e tente novamente.[OPERAÇÃO NÃO CONCLUÍDA]");
            } else if(cCorrente.ativo == 0){
                return BadRequestResult("[INACTIVE_ACCOUNT] - A conta indicada está inativa.[OPERAÇÃO NÃO CONCLUÍDA]");
            } else {

                foreach(var item in mov){
                    if (item.idcontacorrente == idCC){
                        if (item.tipomovimento.toUpper() == "C"){
                            valorC =+ item.valor;
                        }
                    } else if(item.tipomovimento.toUpper() == "D"){
                        valorD =+ item.valor;
                    }
                }

                valorS = valorC - valorD;

                return OK("Conta Corrente: " + cCorrente.numero + " Titular: " + cCorrente.nome + " Data/Hora Consulta: " + dataRet.toString() + " Saldo em conta: " + valorS); 
            }
        }
    }
}