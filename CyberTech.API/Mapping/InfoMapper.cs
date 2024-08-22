using CyberTech.API.ModelViews.News;
using CyberTech.Core.Dto.News;

namespace CyberTech.API.Mapping
{
    public static class InfoMapper
    {
        public static InfoModel ConvertToModelApi(InfoDto dto)
        {
            return new InfoModel(
                id: dto.Id,
                title: dto.Title,
                text: dto.Text,
                date: dto.Date,
                imageId: dto.ImageId);
        }

        public static List<InfoModel> ConvertToModelApi(List<InfoDto> dtos) => dtos.Select(ConvertToModelApi).ToList();

        public static CreatingInfoDto ConvertToDto(CreatingInfoModel modelApi)
        {
            return new CreatingInfoDto(
                title: modelApi.Title,
                text: modelApi.Text,
                date: modelApi.Date,
                imageId: modelApi.ImageId);
        }

        public static UpdatingInfoDto ConverToDto(UpdatingInfoModel modelApi)
        {
            return new UpdatingInfoDto(
                title: modelApi.Title,
                text: modelApi.Text,
                date: modelApi.Date,
                imageId: modelApi.ImageId);
        }
    }
}
