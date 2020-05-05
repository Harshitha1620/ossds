UPDATE S SET RB_code=m.mandcode  from 
SeedV3.dbo.Seed_Mst_Mandal s inner join MSP.dbo.EP_Mst_Mandal m 
on s.DistCode=m.LG_dist_Code and UPPER(s.MandName)=upper(m.MandName) where s.DistCode=512 and Yr='2020-21'

UPDATE S SET RB_code=m.mandcode , mandcode_LG=LG_Mand_code, MandName_Tel=m.MandName_Tel from 
SeedV3.dbo.Seed_Mst_Mandal s inner join MSP.dbo.EP_Mst_Mandal m 
on s.DistCode=m.LG_dist_Code and s.RB_Code=m.Mandcode where s.DistCode=512 and Yr='2020-21'

select * from EP_Mst_Mandal where LG_dist_Code=512
select * from SeedV3.dbo.Seed_Mst_Mandal where Yr='2020-21' and DistCode=512 and rb_code is null
--update SeedV3.dbo.Seed_Mst_Mandal set rb_code=6 where Yr='2020-21' and DistCode=512 and MandCode='12'
--delete from SeedV3.dbo.Seed_Mst_Mandal where Yr='2020-21' and DistCode=512 and MandCode='14'
