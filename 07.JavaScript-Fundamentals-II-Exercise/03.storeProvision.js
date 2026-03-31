function solve(arr1, arr2){
    let store = {} // ще ползваме този обект като kvp колекция (речник)

    for (let i = 0; i < arr1.length; i+=2) {
        const product = arr1[i]    // четен индекс
        const quantity = Number(arr1[i+1]) // нечетен индекс

        store[product] = quantity // всеки път си добавям родукт (ключ) и стойност (количество)
    }

    for (let i = 0; i < arr2.length; i+=2) {
        const product = arr2[i]
        const quantity = Number(arr2[i+1])
        
        // проверявам дали имам такъв родукт (ключ) в магазина
        if(store.hasOwnProperty(product)){
            store[product] += quantity
        } else {
            store[product] = quantity
        }
    }

    for (const key in store) {
        console.log(`${key} -> ${store[key]}`)     
    }
}

solve(
    ['Chips', '5', 'CocaCola', '9', 'Bananas', '14', 'Pasta', '4', 'Beer', '2'],
    ['Flour', '44', 'Oil', '12', 'Pasta', '7', 'Tomatoes', '70', 'Bananas', '30']
)