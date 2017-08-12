namespace Business_Layer
{
    using Business_Layer.Property_Layer;
    using Database_Layer;
    using System;

    public class clsUpdateCoachByLevel
    {
        private clsDBConnect DbConn = new clsDBConnect();

        public void InsertUpdateData(objUpdateCoachByLevel oUpdateCoachByLevel)
        {
            object[,] arrParameter = new object[,] { { "mfldLocationCode", oUpdateCoachByLevel.LocationCode }, { "mfldClassCode", oUpdateCoachByLevel.ChangedLeval }, { "mfldCoacherCode", oUpdateCoachByLevel.CoacherCode }, { "mfldAssCoacherCode", oUpdateCoachByLevel.AssCoacherCode }, { "mfldChangedDate", oUpdateCoachByLevel.ChangedDate.ToString("yyyy-MM-dd") }, { "mfldDayType", oUpdateCoachByLevel.DayType } };
            this.DbConn.Insert("sp_update_coach_ass_caoch_by_level", arrParameter);
        }
    }
}

