using System;
using TravelAgency.Model.Cache;

namespace TravelAgency.BLL.Redis
{
    public class EditMutex
    {
        private static TimeSpan _delayTimeSpan = TimeSpan.FromSeconds(10);



        public static bool Lock(Model.Visa visa, Model.AuthUser user)
        {
            EditingVisa edv = new EditingVisa()
            {
                Visa_Id = visa.Visa_id.ToString(),
                GroupNo = visa.GroupNo,
                EditingPerson = user.UserName,
                EditingWorkId = user.WorkId,
                StartEditTime = DateTime.Now
            };
            return Common.Cache.Redis.Client.Set(visa.Visa_id.ToString(), edv, _delayTimeSpan);
        }

        public static bool Release(Model.Visa visa)
        {
            return Common.Cache.Redis.Client.Remove(visa.Visa_id.ToString());
        }

        public static bool ExtendUseTime(Model.Visa visa)
        {
            return Common.Cache.Redis.Client.ExpireEntryIn(visa.Visa_id.ToString(), _delayTimeSpan);
        }

        public static bool IsEditing(string guid)
        {
            return Common.Cache.Redis.Client.Get<EditingVisa>(guid) != null;
        }




    }
}
