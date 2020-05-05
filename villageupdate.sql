update t set rb_code=s.rbvill, ppb_Prefix=s.PPBNO_Prefix, VillCode_LG=s.VillCode_LG
from SeedV3.dbo.Seed_Mst_Village t inner join (
select * from
(select v.DistCode as rbdist,m.LG_dist_Code, v.Mandcode as rbmand,VillCode as rbvill,VillName as rbvillnm,
ppbno_prefix,VillCode_LG from MSP.dbo.EP_Mst_Village v inner join 
MSP.dbo.EP_Mst_Mandal m on v.DistCode=v.DistCode and v.MandCode=m.Mandcode ) A inner join
(select v.DistCode as lgdist,m.MandCode,m.RB_Code,v.VillCode,v.VillName,v.Yr,v.Seasn
from SeedV3.dbo.Seed_Mst_Village v inner join SeedV3.dbo.Seed_Mst_Mandal m on
v.DistCode=m.DistCode and v.MandCode=m.Mandcode and v.Yr=m.Yr and v.Seasn=m.Seasn where v.Yr='2020-21')B 
on A.LG_dist_Code=b.lgdist and a.rbmand=b.RB_Code and a.rbvillnm=b.VillName) s 
on t.DistCode=s.lgdist and t.MandCode=s.MandCode and t.Yr=s.Yr and t.Seasn=s.Seasn and s.rbvillnm=t.VillName--9047