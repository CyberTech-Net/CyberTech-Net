using CyberTech.Core.Dto.News;
using CyberTech.Domain.Models.Handbooks;

namespace CyberTech.Core.Mapping
{
    public static class InfoMapper 
    {
        public static InfoEntity ConvertToBaseModel(CreatingInfoDto dto)
        {
            return InfoEntity.CreateNewInstanse(
                title: dto.Title,
                text: dto.Text,
                date: dto.Date,
                imageId: dto.ImageId);
        }

        public static InfoDto ConvertToDto(InfoEntity dbEntity)
        {
            return new InfoDto(
                id: dbEntity.Id,
                title: dbEntity.Title,
                text: dbEntity.Text,
                date: dbEntity.Date,
                imageId: dbEntity.ImageId);
        }

        public static List<InfoDto> ConvertToDto(List<InfoEntity> dbEntities) => dbEntities.Select(ConvertToDto).ToList();
    }
}
