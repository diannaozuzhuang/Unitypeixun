using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace biaolei
{
    public class Fenshu
    {
        private long fenshu_id;
        private string user_name;
        private float fenshu_guankaname;
        private float fenshu_defen;
        //private Date fenshu_date;

        public float getFenshu_guankaname()
        {
            return fenshu_guankaname;
        }

        public void setFenshu_guankaname(float fenshu_guankaname)
        {
            this.fenshu_guankaname = fenshu_guankaname;
        }

        public long getFenshu_id()
        {
            return fenshu_id;
        }

        public void setFenshu_id(long fenshu_id)
        {
            this.fenshu_id = fenshu_id;
        }

        public string getUser_name()
        {
            return user_name;
        }

        public void setUser_name(string user_name)
        {
            this.user_name = user_name;
        }


        public float getFenshu_defen()
        {
            return fenshu_defen;
        }

        public void setFenshu_defen(float fenshu_defen)
        {
            this.fenshu_defen = fenshu_defen;
        }

       /* public Date getFenshu_date()
        {
            return fenshu_date;
        }

        public void setFenshu_date(Date fenshu_date)
        {
            this.fenshu_date = fenshu_date;
        }*/
    }
}
