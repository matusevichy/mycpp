# Additional clean files
cmake_minimum_required(VERSION 3.16)

if("${CONFIG}" STREQUAL "" OR "${CONFIG}" STREQUAL "Debug")
  file(REMOVE_RECURSE
  "CMakeFiles\\appLess1_autogen.dir\\AutogenUsed.txt"
  "CMakeFiles\\appLess1_autogen.dir\\ParseCache.txt"
  "appLess1_autogen"
  )
endif()
