using AutoMapper;
using CostMatrix.Core.Domain;
using CostMatrix.Web.Models;
using MongoDB.Bson;
using System;

namespace CostMatrix.Web.Bootstrap
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.CreateMap<Client, ClientEditModel>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id.ToString()));

            Mapper.CreateMap<Project, ProjectEditModel>()
                  .ForMember(d => d.Id, o => o.MapFrom(s => s.Id.ToString()))
                  .ForMember(d => d.ClientName, o=> o.Ignore())
                  .ForMember(d => d.ClientId, o => o.Ignore());

            Mapper.CreateMap<Project, ProjectViewModel>()
                  .ForMember(d => d.Id, o => o.MapFrom(s => s.Id.ToString()))
                  .ForMember(d => d.Matrixes, o => o.Ignore())
                  .ForMember(d => d.CreatedBy, o => o.MapFrom(s => s.CreatedBy.Replace("2020DIGITAL\\", string.Empty)))
                  .ForMember(d => d.CreatedOn, o => o.MapFrom(s => s.CreatedOn.ToLocalTime().ToString()));

            Mapper.CreateMap<Client, ProjectEditModel>()
                  .ForMember(d => d.ClientId, o => o.MapFrom(s => s.Id.ToString()))
                  .ForMember(d => d.ClientName, o => o.MapFrom(s => s.Name))
                  .ForMember(d => d.Id, o => o.MapFrom(s => s.Projects[0].Id))
                  .ForMember(d => d.Name, o => o.MapFrom(s => s.Projects[0].Name));

            Mapper.CreateMap<Client, ClientViewModel>()
                .ForMember(d => d.CreatedBy, o => o.MapFrom(s => s.CreatedBy.Replace("2020DIGITAL\\", string.Empty)))
                .ForMember(d => d.CreatedOn, o => o.MapFrom(s => s.CreatedOn.ToLocalTime().ToString()));

            Mapper.CreateMap<Setting, SettingEditModel>();

            Mapper.CreateMap<SettingEditModel, Setting>()
                .ForMember(d => d.Id, o => o.Ignore());

            Mapper.CreateMap<MatrixEditModel, Matrix>()
                  .ForMember(d => d.Id, o => o.Ignore())
                  .ForMember(d => d.ProjectId, o => o.MapFrom(s => ObjectId.Parse(s.ProjectId)));

            Mapper.CreateMap<MatrixSection, Matrix.Section>();

            Mapper.CreateMap<MatrixSectionItem, Matrix.Section.Item>();

            Mapper.CreateMap<Matrix, MatrixViewModel>()
                .ForMember(d => d.CreatedBy, o => o.MapFrom(s => s.CreatedBy.Replace("2020DIGITAL\\", string.Empty)))
                .ForMember(d => d.CreatedOn, o => o.MapFrom(s => s.CreatedOn.ToLocalTime().ToString()));

            Mapper.CreateMap<Matrix, MatrixEditModel>()
                .ForMember(d => d.MatrixId, o => o.MapFrom(s => s.Id.ToString()))
                .ForMember(d => d.ClientName, o => o.Ignore())
                .ForMember(d => d.FrontEndTotal, o => o.Ignore())
                .ForMember(d => d.BackEndTotal, o => o.Ignore())
                .ForMember(d => d.DesignTotal, o => o.Ignore())
                .ForMember(d => d.ArtDirectorTotal, o => o.Ignore())
                .ForMember(d => d.ProducerTotal, o => o.Ignore())
                .ForMember(d => d.AccountDirectorTotal, o => o.Ignore())
                .ForMember(d => d.ServerManagementTotal, o => o.Ignore())
                .ForMember(d => d.SeoTotal, o => o.Ignore())
                .ForMember(d => d.CopyrighterTotal, o => o.Ignore())
                .ForMember(d => d.OtherTotal, o => o.Ignore())
                .ForMember(d => d.TestingTotal, o => o.Ignore())
                .ForMember(d => d.ProjectManagementTotal, o => o.Ignore())
                .ForMember(d => d.Total, o => o.Ignore())
                .ForMember(d => d.CreatedBy, o => o.MapFrom(s => s.CreatedBy.Replace("2020DIGITAL\\", string.Empty)))
                .ForMember(d => d.CreatedOn, o => o.MapFrom(s => s.CreatedOn.ToLocalTime().ToString()));

            Mapper.CreateMap<Matrix.Section, MatrixSection>()
                .ForMember(d => d.FrontEndTotal, o => o.Ignore())
                .ForMember(d => d.BackEndTotal, o => o.Ignore())
                .ForMember(d => d.DesignTotal, o => o.Ignore())
                .ForMember(d => d.ArtDirectorTotal, o => o.Ignore())
                .ForMember(d => d.ProducerTotal, o => o.Ignore())
                .ForMember(d => d.AccountDirectorTotal, o => o.Ignore())
                .ForMember(d => d.ServerManagementTotal, o => o.Ignore())
                .ForMember(d => d.SeoTotal, o => o.Ignore())
                .ForMember(d => d.CopyrighterTotal, o => o.Ignore())
                .ForMember(d => d.OtherTotal, o => o.Ignore())
                .ForMember(d => d.TestingTotal, o => o.Ignore())
                .ForMember(d => d.ProjectManagementTotal, o => o.Ignore())
                .ForMember(d => d.Total, o => o.Ignore())
                .ForMember(d => d.UniqueId, o => o.MapFrom(s => Guid.NewGuid()));

            Mapper.CreateMap<Matrix.Section.Item, MatrixSectionItem>()
                .ForMember(d => d.Total, o => o.Ignore())
                .ForMember(d => d.HasMore, o => o.Ignore())
                .ForMember(d => d.UniqueId, o => o.MapFrom(s => Guid.NewGuid()));
        }
    }
}