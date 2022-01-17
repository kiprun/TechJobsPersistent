--Part 1
ID Int
Name LongText
Employer INT

--Part 2
SELECT name
From employers
WHERE location = "Saint Louis"
--Part 3
SELECT name, description
FROM skills
INNER JOIN JobSkills 
ON Skills.Id = JobSkills.SkillId
WHERE JobSkills.JobId is not null
ORDER BY name ASC
