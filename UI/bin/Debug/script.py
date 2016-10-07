import clr

clr.AddReference("System.Windows.Forms")
clr.AddReference("UI.exe")

from UI import MainForm

api = MainForm()
streets = api.Streets
print(streets[1].Letter)
print(streets[1].Coordinate)

print([ x.Title + 'no coord' if x.Coordinate is not None else 'X' for x in streets ])

