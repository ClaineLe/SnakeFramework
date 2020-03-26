local SubPanel = {

}
setmetatable(SubPanel, {__index = UIPanel})

function SubPanel:OnLoadSuccess( )
	print("SubPanel:OnLoadSuccess")
end

function SubPanel:OnRelease( )
end

return SubPanel