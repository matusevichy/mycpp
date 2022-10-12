# Additional clean files
cmake_minimum_required(VERSION 3.16)

if("${CONFIG}" STREQUAL "" OR "${CONFIG}" STREQUAL "Debug")
  file(REMOVE_RECURSE
  "Beekeepers_diary_autogen"
  "CMakeFiles\\Beekeepers_diary_autogen.dir\\AutogenUsed.txt"
  "CMakeFiles\\Beekeepers_diary_autogen.dir\\ParseCache.txt"
  )
endif()
