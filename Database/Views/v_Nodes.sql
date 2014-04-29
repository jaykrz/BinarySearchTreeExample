CREATE VIEW v_Nodes 
AS
SELECT 
	Node.Id,
	Value,
	Parent_Id AS ParentId,
	LeftChild_Id AS LeftId,
	RightChild_Id AS RightId,
	CASE WHEN Tree.Id IS NOT NULL THEN 1 ELSE 0 END AS IsRoot
FROM Node
LEFT OUTER JOIN Tree ON Node.Id = Tree.Root_Id

