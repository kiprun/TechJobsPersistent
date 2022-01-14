--Part 1
SELECT *
FROM jobs

--Part 2
SELECT name
From employers
WHERE location = "Saint Louis"
--Part 3
SELECT *
FROM skills
INNER JOIN JobSkills 
ON Skills.Id = JobSkills.SkillId
WHERE JobSkills.JobId is not null
ORDER BY name ASC
