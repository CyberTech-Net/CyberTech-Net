using CyberTech.Core.Dto.News;
using CyberTech.Domain.Models.Handbooks;

namespace CyberTech.Core.Mapping
{
    public static class NewsMapper 
    {
        public static News ConvertToBaseModel(CreatingNewsDto dto)
        {
            return News.CreateNewInstanse(
                title: dto.Title,
                text: dto.Text,
                date: dto.Date,
                imageId: dto.ImageId) ;
        }

        public static NewsDto ConvertToDto(News dbEntity)
        {
            return new NewsDto(
                id: dbEntity.Id,
                title: dbEntity.Title,
                text: dbEntity.Text,
                date: dbEntity.Date,
                imageId: dbEntity.ImageId);
        }

        public static List<NewsDto> ConvertToDto(List<News> dbEntities) => dbEntities.Select(ConvertToDto).ToList();
    }
}
