function checkForDizziness(worker) {
    if (worker.dizziness) {
        worker.levelOfHydrated += 0.1 * worker.weight * worker.experience
    }

    return worker;
}



checkForDizziness({
    weight: 80,
    experience: 1,
    levelOfHydrated: 0,
    dizziness: true
}
)