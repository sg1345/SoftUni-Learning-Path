count_packages_pens = int(input())
count_packages_markers = int(input())
litres_desk_cleaner = int(input())
discount_percentage = int(input())

package_pens = 5.80
package_markers = 7.20
cleaner_one_liter = 1.20

discount_rate = discount_percentage / 100

total = ((count_packages_pens * package_pens) +
         (count_packages_markers * package_markers) +
         (litres_desk_cleaner * cleaner_one_liter))


total_after_discount = total - (total * discount_rate)

print(total_after_discount)