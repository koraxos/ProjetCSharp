SELECT COUNT(*),SUM(CASE WHEN DET.score=20 THEN 1 ELSE 0 END) 
from Hist_Detail as DET, Hist_generale,Enfant_Hist_Detail,Enfant_Hist_generale,Enfant
where DET.score=20
 and Hist_generale.id_hist_generale=Enfant_Hist_generale.id_hist_generale
 and Enfant_Hist_generale.id_enfant=Enfant_Hist_Detail.id_enfant