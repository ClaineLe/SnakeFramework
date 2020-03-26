local CSPath = CS.System.IO.Path

--获取目录路径
function path_get_dir_fullname(filepath)
	return CSPath.GetDirectoryName(filepath)
end

--获取文件名
function path_get_filename( filepath )
	return CSPath.GetFileName(filepath)
end

--去除扩展名
function path_get_filename_without_extension(filepath)
	return CSPath.GetFileNameWithoutExtension(filepath)
end

--获取扩展名
function path_get_extension(filepath)
	return CSPath.GetExtension(filepath)
end