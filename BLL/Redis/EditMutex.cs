using System;
using Newtonsoft.Json;
using TravelAgency.Model.Cache;

namespace TravelAgency.BLL.Redis
{
    public class EditMutex
    {
        private static readonly TimeSpan DelayTimeSpan = TimeSpan.FromSeconds(10);

        private static string getMutexKey(string visaId)
        {
            return $"editing_visa_mutex:{visaId}";
        }

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
            //return Common.Cache.Redis.Client.Set(getMutexKey(visa.Visa_id.ToString()), edv, DelayTimeSpan);
            return Common.Cache.Redis.Client.StringSet(getMutexKey(visa.Visa_id.ToString()),
                JsonConvert.SerializeObject(edv), DelayTimeSpan);
        }

        public static bool Release(Model.Visa visa)
        {
            //return Common.Cache.Redis.Client.Remove(getMutexKey(visa.Visa_id.ToString()));
            return Common.Cache.Redis.Client.KeyDelete(getMutexKey(visa.Visa_id.ToString()));
        }

        public static bool ExtendUseTime(Model.Visa visa)
        {
            //return Common.Cache.Redis.Client.ExpireEntryIn(getMutexKey(visa.Visa_id.ToString()), DelayTimeSpan);
            return Common.Cache.Redis.Client.KeyExpire(getMutexKey(visa.Visa_id.ToString()), DelayTimeSpan);
        }

        public static bool IsEditing(Model.Visa visa)
        {
            //return Common.Cache.Redis.Client.GetTimeToLive(getMutexKey(visa.Visa_id.ToString())).TotalMilliseconds > 0;
            var exp = Common.Cache.Redis.Client.StringGetWithExpiry(getMutexKey(visa.Visa_id.ToString()));
            return exp.Expiry.HasValue && exp.Expiry.Value.TotalMilliseconds > 0;
        }

        public static EditingVisa GetEditingInfo(Model.Visa visa)
        {
            //return Common.Cache.Redis.Client.Get<Model.Cache.EditingVisa>(getMutexKey(visa.Visa_id.ToString()));
            var ret = Common.Cache.Redis.Client.StringGet(getMutexKey(visa.Visa_id.ToString()));
            return JsonConvert.DeserializeObject<Model.Cache.EditingVisa>(ret);
        }
    }
}
