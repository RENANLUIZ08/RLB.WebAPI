using App.RLB.Application.DTO;
using App.RLB.Domain.Entity;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.RLB.Application
{
    public class MappingEntity : Profile
    {
        public MappingEntity()
        {

            #region Mapping Client/ClienteDTO
            CreateMap<Client, ClienteDTO>().ConstructUsing(c => ClienteDTO.MontarDTO(c)).ReverseMap();
            #endregion
            #region Mapping Person/PessoaDTO
            CreateMap<Person, PessoaDTO>().ConstructUsing(c => PessoaDTO.MontarDTO(c)).ReverseMap();
            #endregion
            #region Mapping Physical/FisicaDTO
            CreateMap<PhysicalPerson, PFisicaDTO>().ConstructUsing(c => PFisicaDTO.MontarDTO(c)).ReverseMap();
            #endregion
            #region Mapping Legal/JuridicaDTO
            CreateMap<LegalPerson, PJuridicaDTO>().ConstructUsing(c => PJuridicaDTO.MontarDTO(c)).ReverseMap();
            #endregion
            #region Mapping Address/EnderecoDTO
            CreateMap<Address, EnderecoDTO>().ConstructUsing(c => EnderecoDTO.MontarDTO(c)).ReverseMap();
            #endregion
            #region Mapping Contact/ContatoDTO
            CreateMap<Contact, ContatoDTO>().ConstructUsing(c => ContatoDTO.MontarDTO(c)).ReverseMap();
            #endregion
        }
    }
}
