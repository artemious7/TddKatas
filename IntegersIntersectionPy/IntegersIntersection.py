def IntegersIntersection(a: list, b: list):
    results = []
    for a_item in a:
        for b_item in b:
            if a_item == b_item and a_item not in results:
                results.append(a_item)
    return results