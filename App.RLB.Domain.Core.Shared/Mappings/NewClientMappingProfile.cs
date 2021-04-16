using App.RLB.Domain.Core.Shared.DTO;
using App.RLB.Domain.Core.Shared.DTO.ClienteDTO;
using App.RLB.Domain.Entity;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App.RLB.Domain.Core.Shared.Mappings
{
    public class NewClientMappingProfile : Profile
    {
        public NewClientMappingProfile()
        {
            #region Mapping Client/ClienteDTO
            CreateMap<Client, NovoClienteDTO>().ConstructUsing(c => NovoClienteDTO.MontarDTO(c)).ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();
            #endregion
            //#region Mapping Person/PessoaDTO
            //CreateMap<Person, PessoaDTO>().ConstructUsing(c => PessoaDTO.MontarDTO(c)).ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();
            //#endregion
            //#region Mapping Physical/FisicaDTO
            //CreateMap<PhysicalPerson, PFisicaDTO>().ConstructUsing(c => PFisicaDTO.MontarDTO(c)).ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();
            //#endregion
            //#region Mapping Legal/JuridicaDTO
            //CreateMap<LegalPerson, PJuridicaDTO>().ConstructUsing(c => PJuridicaDTO.MontarDTO(c)).ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();
            //#endregion
            //#region Mapping Address/EnderecoDTO
            //CreateMap<Address, EnderecoDTO>().ConstructUsing(c => EnderecoDTO.MontarDTO(c)).ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();
            //#endregion
            //#region Mapping Contact/ContatoDTO
            //CreateMap<Contact, ContatoDTO>().ConstructUsing(c => ContatoDTO.MontarDTO(c)).ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();
            //#endregion
        }

    }
}
