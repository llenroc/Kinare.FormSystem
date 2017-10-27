using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DanielMaldonado.Inquest.Utils.Enums.Dto;
using Kinare.FormSystem;

namespace DanielMaldonado.Inquest.Utils.Enums
{
    public class EnumService : FormSystemAppServiceBase, IEnumService
    {
        private const string SystemName = "FormSystem";
        public IList<EnumDto> GetEnumList(string request)
        {
            var result = new List<EnumDto>();
            var enumType = Type.GetType(string.Format("Kinare.FormSystem.Enums.{0}, Kinare.FormSystem.Core", request), false);

            if (enumType == null && enumType.IsEnum)
                return result;

            foreach (var enumName in Enum.GetNames(enumType))
            {
                var systemEnum = new EnumDto();

                systemEnum.KeyName = enumName;
                systemEnum.Value = Convert.ToUInt16(Enum.Parse(enumType, enumName));
                systemEnum.LocalizationValue = L(string.Format("{0}.{1}.{2}", SystemName, request, enumName));

                result.Add(systemEnum);
            }

            return result;
        }
    }
}
