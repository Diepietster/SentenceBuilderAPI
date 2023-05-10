using AutoMapper;
using SentenceBuilderAPI.Models;
using SentenceBuilderAPI.Models.DTOModels.SentenceDTO;
using SentenceBuilderAPI.Models.DTOModels.WordDTO;

namespace SentenceBuilderAPI.MappingConfig
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<SentenceDTOCreate, Sentence>().ReverseMap();
            CreateMap<WordsDTOCreate, Words>().ReverseMap();
        }
    }
}
