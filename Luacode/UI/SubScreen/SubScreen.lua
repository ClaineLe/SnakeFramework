local SubScreen = {

}
setmetatable(SubScreen, {__index = UIBaseScreen})

function SubScreen:OnLoadSuccess( )
	print("SubScreen:OnLoadSuccess")
end

function SubScreen:OnRelease( )
end

return SubScreen