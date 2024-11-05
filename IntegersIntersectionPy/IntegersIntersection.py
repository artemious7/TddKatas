def DoublyNestedLoop(a: list, b: list):
    results = []
    for a_item in a:
        for b_item in b:
            if a_item == b_item and a_item not in results:
                results.append(a_item)
    return results

def UseSetForResults(a: list, b: list):
    results = set()
    for a_item in a:
        for b_item in b:
            if a_item == b_item:
                results.add(a_item)
    return list(results)
