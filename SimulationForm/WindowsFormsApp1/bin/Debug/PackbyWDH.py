import sys

sys.path.append(r'C:\Program Files\IronPython 3.4\Lib')
import random
import math
from operator import itemgetter, attrgetter

# from matplotlib.patches import Rectangle,Circle
# import matplotlib.pyplot as plt
# import mpl_toolkits.mplot3d.art3d as art3d
class Axis:
    WIDTH = 0
    DEPTH = 1
    HEIGHT = 2
    ALL = [WIDTH, DEPTH, HEIGHT]

class RotationType:
    RT_WDH = 0
    RT_DWH = 1
    ALL = [RT_WDH, RT_DWH]

# from mpl_toolkits.mplot3d import Axes3D
# from mpl_toolkits.mplot3d.art3d import Poly3DCollection
# import numpy as np
# import matplotlib.pyplot as plt

# def cuboid_data2(o, size=(1,1,1)):
#     X = [[[0, 1, 0], [0, 0, 0], [1, 0, 0], [1, 1, 0]],
#          [[0, 0, 0], [0, 0, 1], [1, 0, 1], [1, 0, 0]],
#          [[1, 0, 1], [1, 0, 0], [1, 1, 0], [1, 1, 1]],
#          [[0, 0, 1], [0, 0, 0], [0, 1, 0], [0, 1, 1]],
#          [[0, 1, 0], [0, 1, 1], [1, 1, 1], [1, 1, 0]],
#          [[0, 1, 1], [0, 0, 1], [1, 0, 1], [1, 1, 1]]]
#     X = np.array(X).astype(float)
#     for i in range(3):
#         X[:,:,i] *= size[i]
#     X += np.array(o)
#     return X

# def plotCubeAt2(positions,sizes=None,colors=None, **kwargs):
#     if not isinstance(colors,(list,np.ndarray)): colors=["C0"]*len(positions)
#     if not isinstance(sizes,(list,np.ndarray)): sizes=[(1,1,1)]*len(positions)
#     g = []
#     for p,s,c in zip(positions,sizes,colors):
#         g.append( cuboid_data2(p, size=s) )
#     return Poly3DCollection(np.concatenate(g),  
#                             facecolors=np.repeat(colors,6), **kwargs)
# def box(m):
#     k = m[-8]
#     positions = m[k]
#     sizes = m[k+1]
#     colors = m[k+2]
#     fig = plt.figure()
#     ax = fig.add_subplot(projection='3d')
#     # ax.set_aspect('equal')
#     pc = plotCubeAt2(positions,sizes,colors=colors, edgecolor="k")
#     ax.add_collection3d(pc)    
#     ax.set_xlim([0,1200])
#     ax.set_ylim([0,1200])
#     ax.set_zlim([0,1200])
#     # ax.set_xlim([0,630])
#     # ax.set_ylim([0,630])
#     # ax.set_zlim([0,630])
#     plt.show()

    
def rect_intersect(item1, item2, x, y):
    d1 = item1.get_dimension()
    d2 = item2.get_dimension()

    cx1 = item1.position[x] + d1[x]/2
    cy1 = item1.position[y] + d1[y]/2
    cx2 = item2.position[x] + d2[x]/2
    cy2 = item2.position[y] + d2[y]/2

    ix = max(cx1, cx2) - min(cx1, cx2)
    iy = max(cy1, cy2) - min(cy1, cy2)

    return ix < (d1[x]+d2[x])/2 and iy < (d1[y]+d2[y])/2 

def intersect(item1, item2):
    return (
        rect_intersect(item1, item2, Axis.WIDTH, Axis.HEIGHT) and
        rect_intersect(item1, item2, Axis.HEIGHT, Axis.DEPTH) and
        rect_intersect(item1, item2, Axis.WIDTH, Axis.DEPTH)
    )


    
def check_box_upper(item1, item2, x, y, z):
    d1 = item1.get_dimension()
    d2 = item2.get_dimension()

    cx1 = item1.position[x] + d1[x]/2
    cy1 = item1.position[y] + d1[y]/2
    cz1 = item1.position[z] + d1[z]/2
    cx2 = item2.position[x] + d2[x]/2
    cy2 = item2.position[y] + d2[y]/2
    cz2 = item2.position[z] + d2[z]/2

    ix = abs(cx1-cx2)
    iy = abs(cy1-cy2)
    iz = abs(cz1-cz2)
    return ix < (d1[x]+d2[x])/2 and iy < (d1[y]+d2[y])/2 and iz == (d1[z]+d2[z])/2 

def box_upper(item1, item2):
    
    return check_box_upper(item1, item2, Axis.WIDTH, Axis.DEPTH, Axis.HEIGHT)

def external_area_check(item1, item2): 
    # print(box_upper(item1, item2))
    if box_upper(item1, item2):
        d1 = item1.get_dimension()
        d2 = item2.get_dimension()
        item1_x1 = item1.position[0] 
        item1_y1 = item1.position[1]
        item1_x2 = item1.position[0] + d1[0]
        item1_y2 = item1.position[1] + d1[1]
        item2_x1 = item2.position[0] 
        item2_y1 = item2.position[1]
        item2_x2 = item2.position[0] + d2[0]
        item2_y2 = item2.position[1] + d2[1]

        xi1 = max(item1_x1, item2_x1)
        yi1 = max(item1_y1, item2_y1)
        xi2 = min(item1_x2, item2_x2)
        yi2 = min(item1_y2, item2_y2)

        #calculate intersect area
        inter_width = abs(yi2-yi1)
        inter_depth = abs(xi1-xi2)
        inter_area = inter_width*inter_depth

        #item2_area = d2[0]*d2[1]

        return inter_area
    else: return 0



START_POSITION = [0, 0, 0]


class Item:
    def __init__(self, width, depth, height, weight, no, color):
        self.width = width
        self.height = height
        self.depth = depth
        self.weight = weight
        self.no = no
        self.color = color
        self.rotation_type = 0
        self.position = START_POSITION

    def string(self):
        return "%s(%sx%sx%s, weight: %s) vol(%s)" % (
            self.no, self.width, self.height, self.depth, self.weight, self.get_volume()
        )
    def get_volume(self):
        return self.width * self.height * self.depth

    def get_order(self):
        return random.randint(1, 1000)

    def get_pos_ori(self):
        return [self.no, self.position[0] + self.width/2 , self.position[1]+self.depth/2, self.position[2]+self.height, self.rotation_type] 
    def get_pos(self):
        return [self.position[0], self.position[1], self.position[2]]
    def get_COG(self):
        return [(self.position[0] + self.width/2)*self.weight, (self.position[1] + self.depth/2)*self.weight, (self.position[2] + self.height/2)*self.weight]

    def get_pivot_z(self):
        return self.position[2] + self.height
    def get_pivot_x(self):
        return self.position[1] + self.width
    def get_Area(self):
        return self.width*self.depth 
    def get_dimension(self):
        if self.rotation_type == RotationType.RT_WDH:
            dimension = [self.width, self.depth, self.height]
        elif self.rotation_type == RotationType.RT_DWH:
            dimension = [self.depth, self.width, self.height]
        else:
            dimension = []
        return dimension

class Bin:
    def __init__(self, width, depth, height, max_weight):
        self.width = width
        self.height = height
        self.depth = depth
        self.max_weight = max_weight
        self.items = []
        self.unfitted_items = []

    def string(self):
        return "(%sx%sx%s, max_weight:%s) vol(%s)" % (
            self.width, self.depth, self.height, self.max_weight,
            self.get_volume()
        )

    def get_volume(self):
        return self.width * self.height * self.depth

    def get_total_weight(self):
        total_weight = 0

        for item in self.items:
            total_weight += item.weight

        return total_weight

    def put_item(self, item, pivot):
        fit = False
        # valid_item_position = item.position
        item.position = pivot
        external_area = item.get_Area()
        if pivot == [0,0,0]: 
            self.items.append(item)
            fit = True
            return fit
        for i in range(0, len(RotationType.ALL)):
            # item.rotation_type = random.randint(0,1)
            item.rotation_type = 0
            dimension = item.get_dimension()
            # check the limit of pallet
            if (
                self.width < pivot[0] + dimension[0] or
                self.depth < pivot[1] + dimension[1] or
                self.height < pivot[2] + dimension[2]
            ):
                continue

            fit = True
            #check for any intersect items in bin
            for current_item_in_bin in self.items:
                if intersect(current_item_in_bin, item): 
                    fit = False
                    break  
            # check max weight of pallet      
            if fit:
                if self.get_total_weight() + item.weight > self.max_weight:
                    fit = False
                    return fit
            if fit == True:
                if pivot[2] > 0:
                    for current_item_in_bin in self.items:
                        # print(external_area_check(current_item_in_bin, item))
                        # print(current_item_in_bin.get_pos())
                
                        external_area = external_area - external_area_check(current_item_in_bin, item)     
                    if external_area < 0.15 *item.get_Area(): fit = True
                    else: fit = False 

            if fit:
                self.items.append(item)

            if not fit:
                item.position = START_POSITION

            return fit

        if not fit:
            item.position = START_POSITION

        return fit


class Packer:
    def __init__(self):
        self.bins = []
        self.items = []
        self.unfit_items = []
        self.total_items = 0

    def add_bin(self, bin):
        return self.bins.append(bin)
    def add_item(self, item):
        self.total_items = len(self.items) + 1

        return self.items.append(item)

    def pack_to_bin(self, bin, item):
        fitted = False

        if not bin.items:
            response = bin.put_item(item, START_POSITION)

            if not response:
                bin.unfitted_items.append(item)

            return

        for axis in range(0, 3):
            items_in_bin = bin.items
            # items_in_bin.sort(key=lambda item: (item.get_pivot_z()), reverse = False)
            for ib in items_in_bin:
                pivot = [0, 0, 0]
            
                w, d, h = ib.get_dimension()
                if axis == Axis.WIDTH:
                    pivot = [
                        ib.position[0] + w,
                        ib.position[1],
                        ib.position[2]
                    ]
                
                elif axis == Axis.DEPTH:
                    pivot = [
                        ib.position[0],
                        ib.position[1] + d,
                        ib.position[2]
                    ]
                elif axis == Axis.HEIGHT:   
                    pivot = [
                        ib.position[0],
                        ib.position[1],
                        ib.position[2] + h
                    ]
                
                if bin.put_item(item, pivot):
                    fitted = True          
                    
                if fitted: break
            if fitted: break

        if not fitted:
            
            bin.unfitted_items.append(item)

    def pack(self, distribute_items = True):

        # self.bins.sort(
        #     key=lambda bin: bin.get_volume(), reverse=True
        # )
        
        self.items.sort(
            key = lambda item: (item.get_order()), reverse = True
        )
        
        

        for bin in self.bins:
            for item in self.items:
                if(self.items.index(item) == 5):
                    z = 1
                self.pack_to_bin(bin, item)

            if distribute_items:
                for item in bin.items:
                    self.items.remove(item)





    

"""
    for i in range(0,n2):
        i2 = Item(width2, height2, depth2, weight2, 2)
        packer.add_item(i2)    
    for i in range(0,n3):
        i3 = Item(width3, height3, depth3, weight3, 3)
        packer.add_item(i3)
    for i in range(0,n4):
        i4 = Item(width4, height4, depth4, weight4, 4)
        packer.add_item(i4) 
    for i in range(0,n5):
        i5 = Item(width5, height5, depth5, weight5, 5)
        packer.add_item(i5)  
"""


def run(  width1, depth1, height1, weight1, n1, 
          width2, depth2, height2, weight2, n2, 
          width3, depth3, height3, weight3, n3, 
          width4, depth4, height4, weight4, n4):

    solution = []
    for i in range(0,1000):
        packer = Packer()
        # p1 = Bin(630, 630, 630, 50)
        p1 = Bin(1000, 800, 1000, 100)
        packer.add_bin(p1)
        for i in range(0,n1):
            i1 = Item(width1, depth1, height1, weight1, 1, "red")
            packer.add_item(i1)
        for i in range(0,n2):
            i2 = Item(width2, depth2, height2, weight2, 2, "green")
            packer.add_item(i2)    
        for i in range(0,n3):
            i3 = Item(width3, depth3, height3, weight3, 3, "blue")
            packer.add_item(i3)
        for i in range(0,n4):
            i4 = Item(width4, depth4, height4, weight4, 4, "yellow")
            packer.add_item(i4) 
        
        # packer.add_item(Item(width2, depth2, height2, weight2, 2, "green"))
        # packer.add_item(Item(width1, depth1, height1, weight1, 1, "red"))
        # packer.add_item(Item(width1, depth1, height1, weight1, 1, "red"))
        # packer.add_item(Item(width1, depth1, height1, weight1, 1, "red"))
        # packer.add_item(Item(width4, depth4, height4, weight4, 4, "yellow")) 
        # packer.add_item(Item(width3, depth3, height3, weight3, 3, "blue")) 
        # packer.add_item(Item(width3, depth3, height3, weight3, 3, "blue")) 
        # packer.add_item(Item(width2, depth2, height2, weight2, 2, "green")) 
        # packer.add_item(Item(width4, depth4, height4, weight4, 4, "yellow")) 
        # packer.add_item(Item(width3, depth3, height3, weight3, 3, "blue")) 
        # packer.add_item(Item(width4, depth4, height4, weight4, 4, "yellow")) 
        # packer.add_item(Item(width1, depth1, height1, weight1, 1, "red"))
        # packer.add_item(Item(width1, depth1, height1, weight1, 1, "red"))
        # packer.add_item(Item(width3, depth3, height3, weight3, 3, "blue")) 
        # packer.add_item(Item(width2, depth2, height2, weight2, 2, "green")) 
        # packer.add_item(Item(width2, depth2, height2, weight2, 2, "green")) 
        # packer.add_item(Item(width4, depth4, height4, weight4, 4, "yellow")) 
        # packer.add_item(Item(width3, depth3, height3, weight3, 3, "blue")) 
        # packer.add_item(Item(width4, depth4, height4, weight4, 4, "yellow")) 
        # packer.add_item(Item(width1, depth1, height1, weight1, 1, "red"))
        # packer.add_item(Item(width3, depth3, height3, weight3, 3, "blue")) 
        # packer.add_item(Item(width2, depth2, height2, weight2, 2, "green")) 
        # packer.add_item(Item(width4, depth4, height4, weight4, 4, "yellow")) 
        # packer.add_item(Item(width2, depth2, height2, weight2, 2, "green")) 
        # packer.add_item(Item(width1, depth1, height1, weight1, 1, "red"))
        # packer.add_item(Item(width4, depth4, height4, weight4, 4, "yellow")) 
        # packer.add_item(Item(width3, depth3, height3, weight3, 3, "blue"))
        # packer.add_item(Item(width2, depth2, height2, weight2, 2, "green")) 
        # packer.add_item(Item(width1, depth1, height1, weight1, 1, "red"))
        # packer.add_item(Item(width4, depth4, height4, weight4, 4, "yellow")) 
        # packer.add_item(Item(width3, depth3, height3, weight3, 3, "blue"))
        # packer.add_item(Item(width1, depth1, height1, weight1, 1, "red"))
        # packer.add_item(Item(width4, depth4, height4, weight4, 4, "yellow")) 
        # packer.add_item(Item(width3, depth3, height3, weight3, 3, "blue"))
        # packer.add_item(Item(width2, depth2, height2, weight2, 2, "green")) 
        # packer.add_item(Item(width2, depth2, height2, weight2, 2, "green")) 
        a = []
        pos_to_draw = []
        item_vol = []
        color = []
        COG = [0,0,0]
        totalvolume = 0
        w = 0 

        # packer.bins.sort(key=lambda bin: bin.get_volume(), reverse=True)
        # packer.items.sort(key = lambda item: item.get_order())
        packer.pack()
        for b in packer.bins:
            #print(":::::::::::", b.string())
            #print("FITTED ITEMS:")
            for item in b.items:
                
                #print("====> ", item.string())
                a.append(item.get_pos_ori())
                pos_to_draw.append(item.get_pos())
                item_vol.append(item.get_dimension())
                color.append(item.color)
                totalvolume = (totalvolume + item.get_volume()) 
                COG[0] = (COG[0] + item.get_COG()[0])
                COG[1] = (COG[1] + item.get_COG()[1])
                COG[2] = (COG[2] + item.get_COG()[2])
                w = w + item.weight

                #print(a) 
                    
            #print("UNFITTED ITEMS:")
            #for item in b.unfitted_items:
                #print("====> ", item.string())
            

        PercentOfUnuseVolume = (p1.get_volume() - totalvolume)*100/p1.get_volume()
        COG = [COG[0]/w, COG[1]/w, COG[2]/w]
        ErrorOfCOG =  [(packer.bins[0].height-COG[0])*100/packer.bins[0].height, (packer.bins[0].height/2-COG[1])*100/packer.bins[0].height, (packer.bins[0].height-COG[2])*100/packer.bins[0].height]
        MSEofCOG = math.sqrt(ErrorOfCOG[0]**2 + ErrorOfCOG[1]**2 + ErrorOfCOG[2]**2)/3
        m = len(a)
        PercentOfUnFittedBox = (n1+n2+n3+n4-m)*100/(n1+n2+n3+n4)
        estimate1 = MSEofCOG*0.8 + PercentOfUnuseVolume*0 + PercentOfUnFittedBox*0 + COG[2]*100/packer.bins[0].height*0.2  #COG Priorrity
        estimate2 = MSEofCOG*55 + PercentOfUnuseVolume*0.35 + PercentOfUnFittedBox*0 + COG[2]*100/packer.bins[0].height*0.1 #0.55 COG, 0.25 Volume, 0.1 totalBox, o.1 Erro
        estimate3 = MSEofCOG*0 + PercentOfUnuseVolume*1 + PercentOfUnFittedBox*0 + COG[2]*100/packer.bins[0].height*0  #Priority Volume
        estimate4 = MSEofCOG*0 + PercentOfUnuseVolume*0 + PercentOfUnFittedBox*1 + COG[2]*100/packer.bins[0].height*0  #Priority totalbox  
 
        # a.append(len(a))
        # a.append(PercentOfUnuseVolume)
        # a.append(COG)
        # a.append(estimate)
        # solution.append(a)

        aSorted = sorted(a, key = itemgetter(3,1,2))
        aSorted.append(pos_to_draw)
        aSorted.append(item_vol)
        aSorted.append(color)
        aSorted.append(len(a))
        aSorted.append(PercentOfUnuseVolume)
        aSorted.append(COG)
        aSorted.append(MSEofCOG)
        aSorted.append(estimate1)
        aSorted.append(estimate2)
        aSorted.append(estimate3)
        aSorted.append(estimate4)
        solution.append(aSorted)
    
    min1 = solution[0]
    min2 = solution[0]
    min3 = solution[0]
    min4 = solution[0]

    for i in range(0,len(solution)): 
        if min4[-1] > solution[i][-1]:
            min4 = solution[i]
        if min3[-2] > solution[i][-2]:
            min3 = solution[i]
        if min2[-3] > solution[i][-3]:
            min2 = solution[i]
        if min1[-4] > solution[i][-4]:
            min1 = solution[i]
    return min1, min2, min3, min4


# m1,m2,m3,m4 = run(300,300,200,1,10,300,200,150,1,10,225,250,150,1,10,0,0,0,0,0)
# m1,m2,m3,m4 = run(500,500,500,3,10,400,300,200,3,10,300,300,300,5,10,400,500,400,4,10)
# box(m1)
# box(m2) 
# box(m3) 
# box(m4)
# print(m1)
# print(m2)
# print(m3)
# print(m4)