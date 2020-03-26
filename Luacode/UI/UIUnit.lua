local CSButton = CS.UnityEngine.UI.Button
UIUtil = {
	__path = nil,

	mGameObject = nil,
	mTransform = nil,
	mRectTransform = nil,

	mListeners = nil,
}

setmetatable(UIUtil, {__index = ILuaPanelInterface})


function UIUtil:LoadSuccess( screenRoot, luaPath )
	self.mGameObject = screenRoot
	self.mTransform = screenRoot.transform
	self.mListeners = {}

	self.__path = luaPath
	self:OnLoadSuccess()
end
function UIUtil:Release( )
	self:OnRelease()
	self:RemoveListeners()
end

function UIUtil:OnLoadSuccess( )
	-- body
end
function UIUtil:OnRelease( )
	-- body
end

function UIUtil:get_transform( path )
	return self.mTransform:Find(path)
end

function UIUtil:add_button( path, func)
	local node = self:get_transform(path)
	if node then 
		local btn = node:GetComponent(typeof(CSButton))
		if btn then 
			local handler = handler(func, self)
			table.insert(self.mListeners, {key = btn, value = handler})
			btn.onClick:AddListener(handler)
		end
	end
end

function UIUtil:get_subscreen( path, subScreenName)
	local node = self:get_transform(path)
	if node then
		local subScreenName = path_get_filename_without_extension(path) 
		local fullpath = string.format(PathConst.UI_SCREEN_PATH, subScreenName)
		local subScreen = require(fullpath)
		subScreen:LoadSuccess(node, fullpath)
	end
end

function UIUtil:RemoveListeners( )
	for i,v in ipairs(self.mListeners) do
		v.key.onClick:RemoveListener(v.value)
	end
	self.mListeners = {}
end