from snail_sort_module.snail_sort import snail_sort


def main():
    #array = [[1, 2, 3],
    #         [8, 9, 4],
    #         [7, 6, 5]]
    array = [[1, 2, 3, 4, 5, 6],
             [16, 17, 18, 19, 20, 7],
             [15, 24, 23, 22, 21, 8],
             [14, 13, 12, 11, 10, 9]]
    snail_sort(array)


if __name__ == "__main__":
    main()
