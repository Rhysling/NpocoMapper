SELECT
	type,
	name
	--sql
FROM sqlite_schema
WHERE
	(name <> 'sqlite_sequence')
	AND (type IN ('table', 'view'))
ORDER BY
	type,
	name;