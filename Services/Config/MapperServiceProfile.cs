using AutoMapper;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Services.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Services.Config
{
    public class MapperServiceProfile : Profile
    {
        public MapperServiceProfile() 
        {
            CreateMap<User, UserBO>()
                .ForMember(d => d.Requests, o => o.MapFrom(s => s.Requests))
                .ForMember(d => d.EmailConfirmed, o => o.MapFrom(s => s.EmailConfirmed))
                .ReverseMap();

            CreateMap<SupportRequest, SupportRequestBO>()
                .ForMember(d => d.Messages, o => o.MapFrom(s => s.Messages))
                .ReverseMap();

            CreateMap<SupportRequestMessages, SupportRequestMessagesBO>();
            CreateMap<Report, ReportBO>();
        }
    }
}
