using AutoMapper;
using CyberTech.API.ModelViews.News;
using CyberTech.Core.Dto.News;

namespace CyberTech.API.Mapping
{
    public static class NewsMapper
    {
        public static NewsModel ConvertToModelApi(NewsDto dto)
        {
            return new NewsModel(
                id: dto.Id,
                title: dto.Title,
                text: dto.Text,
                date: dto.Date);
        }

        public static List<NewsModel> ConvertToModelApi(List<NewsDto> dtos) => dtos.Select(ConvertToModelApi).ToList(); 

        public static CreatingNewsDto ConvertToDto(CreatingNewsModel modelApi)
        {
            return new CreatingNewsDto(
                title: modelApi.Title,
                text: modelApi.Text,
                date: modelApi.Date,
                imageId: modelApi.ImageId) ;
        }

        public static UpdatingNewsDto ConverToDto(UpdatingNewsModel modelApi)
        {
            return new UpdatingNewsDto(
                title: modelApi.Title,
                text: modelApi.Text,
                date: modelApi.Date,
                imageId: modelApi.ImageId) ;
        }
    }
}
